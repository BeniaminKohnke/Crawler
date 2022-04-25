using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Crawler
{
    public static class DataAccess
    {
        public static string s_currentFileId { get; set; } = string.Empty;
        #region Google
        private readonly static DriveService s_driveService = GetDriveService();
        private readonly static string s_crawlerFileId = GetFileId("DOTNETCRAWLER");
        private readonly static Dictionary<string, string> s_filesWithIds = GetFilesNamesWithIds();
        private static List<string?>? s_configurationList;

        private static DriveService GetDriveService()
        {
            using var stream = new FileStream("client_secret_720612502335-vg4d9fnsp15cbp0kslmh2v0j0u5kh183.apps.googleusercontent.com.json", FileMode.Open, FileAccess.Read);
            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.FromStream(stream).Secrets,
                new string[] { DriveService.Scope.Drive },
                "owner",
                CancellationToken.None,
                new FileDataStore("token.json", true)).Result;

            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "DOTNETCRAWLER",
            });

            return service;
        }

        public static void DownloadConfiguration()
        {
            var fileId = GetFileId("Configuration.json");
            var file = DownloadFile(fileId);

            try
            {
                var jo = JObject.Parse(file);

                var token = jo.SelectToken("$.Files");
                if (token != null)
                {
                    s_configurationList = token.Values<string>().ToList();
                }
            }
            catch (JsonReaderException e)
            {

            }
        }

        public static string GetFileId(string fileName)
        {
            var listRequest = s_driveService.Files.List();

            listRequest.Fields = "nextPageToken, files(name, id)";
            listRequest.Q = string.IsNullOrEmpty(s_crawlerFileId) ? $"name = '{fileName}'" : $"name = '{fileName}' and '{s_crawlerFileId}' in parents";

            return listRequest.Execute().Files.First().Id;
        }

        public static Dictionary<string, string> GetFilesNamesWithIds(string folderName = "")
        {
            var folderId = string.IsNullOrEmpty(folderName) ? s_crawlerFileId : GetFileId(folderName);
            var listRequest = s_driveService.Files.List();

            listRequest.Q = $"'{folderId}' in parents";
            listRequest.Fields = "nextPageToken, files(id, name)";
            var response = listRequest.Execute().Files;

            return response.ToDictionary(k => k.Name, v => v.Id);
        }

        public static Dictionary<string, string> DownloadFiles(string folderName = "")
        {
            var folderId = string.IsNullOrEmpty(folderName) ? s_crawlerFileId : GetFileId(folderName);
            var listRequest = s_driveService.Files.List();

            listRequest.Q = $"'{folderId}' in parents and name = 'ConfigurationFile'";
            listRequest.Fields = "nextPageToken, files(id, name)";
            var files = listRequest.Execute().Files;

            var filesContent = new Dictionary<string, string>();
            foreach (var file in files)
            {
                var getRequest = s_driveService.Files.Get(file.Id);
                var fileContent = new MemoryStream();
                getRequest.DownloadWithStatus(fileContent);
                filesContent.Add(file.Name, Encoding.UTF8.GetString(fileContent.ToArray()));
            }

            return filesContent;
        }

        public static string DownloadFile(string fileId)
        {
            var getRequest = s_driveService.Files.Get(fileId);
            var fileContent = new MemoryStream();
            getRequest.DownloadWithStatus(fileContent);

            return Encoding.UTF8.GetString(fileContent.ToArray());
        }
        #endregion

        public static void SaveProduct(Product product)
        {
            if(s_filesWithIds.ContainsKey(product.Sku + ".json"))
            {
                //s_filesWithIds[product.Sku]

                var deleteRequest = s_driveService.Files.Delete(s_filesWithIds[product.Sku + ".json"]);
                deleteRequest.Execute();
            }

            var fileData = new Google.Apis.Drive.v3.Data.File
            {
                Name = $"{product.Sku}.json",
                Parents = new List<string>
                {
                    s_crawlerFileId,
                    //s_currentFileId
                },
                MimeType = "application/json", //"application/json"
            };

            var serializedProduct = JsonConvert.SerializeObject(product);
            using(var fileContent = new MemoryStream(Encoding.UTF8.GetBytes(serializedProduct)))
            {
                var createRequest = s_driveService.Files.Create(fileData, fileContent, fileData.MimeType);
                createRequest.Fields = "id";
                var x = createRequest.Upload();
            }
        }

        public static void SaveLog(Logger.LogLevel level, string message, string memberName)
        {

        }
    }
}
