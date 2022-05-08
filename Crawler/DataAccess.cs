using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Newtonsoft.Json;
using System.Text;

namespace Crawler
{
    public static class DataAccess
    {
        private readonly static DriveService s_driveService;
        private readonly static string s_crawlerFolderId;
        private readonly static string s_configurationsFolderId;
        private readonly static string s_dataFolderId;
        private readonly static string s_logFolderId;
        private static Dictionary<string, string> s_dataFoldersWithIds = new();
        private static Dictionary<string, string> s_configurationsWithIds = new();
        private static Dictionary<string, string> s_currentFolderFilesIds = new();
        static DataAccess()
        {
            {
                using var stream = new FileStream("client_secret_696258282970-8kojf5poljetis51caidvaheh4pj7kvi.apps.googleusercontent.com.json", FileMode.Open, FileAccess.Read);
                var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    new string[] { DriveService.Scope.Drive },
                    "owner",
                    CancellationToken.None,
                    new FileDataStore("token.json", true)).Result;

                s_driveService = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "DOTNETCRAWLER",
                });
            }

            {
                var listRequest = s_driveService.Files.List();
                listRequest.Fields = "nextPageToken, files(id)";

                listRequest.Q = $"name = 'DOTNETCRAWLER'";
                s_crawlerFolderId = listRequest.Execute().Files.First().Id;

                listRequest.Q = $"name = 'CONFIG' and '{s_crawlerFolderId}' in parents";
                s_configurationsFolderId = listRequest.Execute().Files.First().Id;

                listRequest.Q = $"name = 'DATA' and '{s_crawlerFolderId}' in parents";
                s_dataFolderId = listRequest.Execute().Files.First().Id;

                listRequest.Q = $"name = 'LOG' and '{s_crawlerFolderId}' in parents";
                s_logFolderId = listRequest.Execute().Files.First().Id;
            }

            UpdateConfigurationFiles();
            UpdateDataFolders();
        }

        public static void UpdateConfigurationFiles()
        {
            var listRequest = s_driveService.Files.List();
            listRequest.Q = $"'{s_configurationsFolderId}' in parents";
            listRequest.Fields = "nextPageToken, files(id, name)";
            var response = listRequest.Execute().Files;
            s_configurationsWithIds = response.ToDictionary(k => k.Name, v => v.Id);
        }

        public static void UpdateDataFolders()
        {
            var listRequest = s_driveService.Files.List();
            listRequest.Q = $"'{s_dataFolderId}' in parents";
            listRequest.Fields = "nextPageToken, files(id, name)";
            var response = listRequest.Execute().Files;
            s_dataFoldersWithIds = response.ToDictionary(k => k.Name, v => v.Id);
        }

        public static void UpdateDataFolderFiles(string folderName)
        {
            s_currentFolderFilesIds.Clear();

            var listRequest = s_driveService.Files.List();
            listRequest.Q = $"'{s_dataFoldersWithIds[folderName]}' in parents";
            listRequest.Fields = "nextPageToken, files(id, name)";
            var response = listRequest.Execute().Files;
            s_currentFolderFilesIds = response.ToDictionary(k => k.Name, v => v.Id);
            s_currentFolderFilesIds.Add("FOLDER", folderName);
        }

        public static Dictionary<string, string> GetProductsFilesNamesWithIds(string folderName = "")
        {
            var folderId = s_dataFoldersWithIds[folderName];
            var listRequest = s_driveService.Files.List();

            listRequest.Q = $"'{folderId}' in parents";
            listRequest.Fields = "nextPageToken, files(id, name)";
            var response = listRequest.Execute().Files;

            return response.ToDictionary(k => k.Name, v => v.Id);
        }

        public static CrawlerConfiguration? DownloadConfiguration(string configName)
        {
            if(s_configurationsWithIds.ContainsKey($"{configName}.json"))
            {
                var getRequest = s_driveService.Files.Get(s_configurationsWithIds[$"{configName}.json"]);
                var fileContent = new MemoryStream();
                getRequest.DownloadWithStatus(fileContent);
                var file = Encoding.UTF8.GetString(fileContent.ToArray());

                try
                {
                    var config = JsonConvert.DeserializeObject<CrawlerConfiguration>(file);
                    return config;
                }
                catch (Exception e)
                {
                    Logger.Log(Logger.LogLevel.ERROR, "Exception while deserializing configuration file", "DATA_ACCESS", e);
                }
            }

            return null;
        }

        public static void SaveConfiguration(CrawlerConfiguration config)
        {
            if (s_configurationsWithIds.ContainsKey(config.ConfigurationName + ".json"))
            {
                var deleteRequest = s_driveService.Files.Delete(s_configurationsWithIds[config.ConfigurationName + ".json"]);
                deleteRequest.Execute();
            }

            var fileData = new Google.Apis.Drive.v3.Data.File
            {
                Name = $"{config.ConfigurationName}.json",
                Parents = new List<string>
                {
                    s_configurationsFolderId,
                },
                MimeType = "application/json",
            };

            var serializedConfig = JsonConvert.SerializeObject(config, Formatting.Indented);
            using var fileContent = new MemoryStream(Encoding.UTF8.GetBytes(serializedConfig));
            var createRequest = s_driveService.Files.Create(fileData, fileContent, fileData.MimeType);
            createRequest.Fields = "id";
            createRequest.Upload();
        }

        private static void CreateFolder(string folderName)
        {
            var fileData = new Google.Apis.Drive.v3.Data.File
            {
                Name = folderName,
                Parents = new List<string>
                {
                    s_dataFolderId,
                },
                MimeType = "application/vnd.google-apps.folder",
            };

            var createRequest = s_driveService.Files.Create(fileData);
            createRequest.Fields = "id";
            createRequest.Execute();
        }

        public static void SaveCrawlerResult(string folderName, List<string> urls)
        {
            if (!s_dataFoldersWithIds.ContainsKey(folderName))
            {
                CreateFolder(folderName);
                UpdateDataFolders();
            }

            if (!s_currentFolderFilesIds.ContainsKey("FOLDER") || !s_currentFolderFilesIds["FOLDER"].Equals(folderName))
            {
                UpdateDataFolderFiles(folderName);
            }
            else if (s_currentFolderFilesIds.ContainsKey("CRAWLING_RESULT.json"))
            {
                var deleteRequest = s_driveService.Files.Delete(s_dataFoldersWithIds["CRAWLING_RESULT.json"]);
                deleteRequest.Execute();
            }

            var fileData = new Google.Apis.Drive.v3.Data.File
            {
                Name = $"CRAWLING_RESULT.json",
                Parents = new List<string>
                {
                    s_dataFoldersWithIds[folderName],
                },
                MimeType = "application/json",
            };

            var serializedResult = JsonConvert.SerializeObject(urls, Formatting.Indented);
            using var fileContent = new MemoryStream(Encoding.UTF8.GetBytes(serializedResult));
            var createRequest = s_driveService.Files.Create(fileData, fileContent, fileData.MimeType);
            createRequest.Fields = "id";
            createRequest.Upload();
        }

        public static void SaveProduct(string folderName, Product product)
        {
            if(!s_dataFoldersWithIds.ContainsKey(folderName))
            {
                CreateFolder(folderName);
                UpdateDataFolders();
            }
            
            if(!s_currentFolderFilesIds.ContainsKey("FOLDER") || !s_currentFolderFilesIds["FOLDER"].Equals(folderName))
            {
                UpdateDataFolderFiles(folderName);
            }
            
            if(s_currentFolderFilesIds.ContainsKey(product.Sku + ".json"))
            {
                var deleteRequest = s_driveService.Files.Delete(s_currentFolderFilesIds[product.Sku + ".json"]);
                deleteRequest.Execute();
            }

            var fileData = new Google.Apis.Drive.v3.Data.File
            {
                Name = $"{product.Sku}.json",
                Parents = new List<string>
                {
                    s_dataFoldersWithIds[folderName],
                },
                MimeType = "application/json",
            };

            var serializedProduct = JsonConvert.SerializeObject(product, Formatting.Indented);
            using var fileContent = new MemoryStream(Encoding.UTF8.GetBytes(serializedProduct));
            var createRequest = s_driveService.Files.Create(fileData, fileContent, fileData.MimeType);
            createRequest.Fields = "id";
            createRequest.Upload();
        }

        public static void SaveLog(Logger.LogObject logObject)
        {
            var fileData = new Google.Apis.Drive.v3.Data.File
            {
                Name = $"{logObject.LogDate}.json",
                Parents = new List<string>
                {
                    s_logFolderId,
                },
                MimeType = "application/json",
            };

            var serializedLog = JsonConvert.SerializeObject(logObject);
            using var fileContent = new MemoryStream(Encoding.UTF8.GetBytes(serializedLog));
            var createRequest = s_driveService.Files.Create(fileData, fileContent, fileData.MimeType);
            createRequest.Fields = "id";
            createRequest.Upload();
        }

        public static string[] GetConfigurations() => s_configurationsWithIds.Select(c => c.Key.Replace(".json", string.Empty)).ToArray();
    }
}
