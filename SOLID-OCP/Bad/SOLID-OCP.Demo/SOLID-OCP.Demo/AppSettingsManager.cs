using System;
using System.IO;
using Newtonsoft.Json;
using SOLID_OCP.Demo.ViewModels;

namespace SOLID_OCP.Demo
{
    /// <summary>
    /// Notification manager
    /// </summary>
    public class AppSettingsManager
    {
        private readonly string _fileName = "app-config.json";

        /// <summary>
        /// Load and deserialize data from configuration
        /// </summary>
        /// <returns></returns>
        public AppSettings Load()
        {
            var file = GetFilePath(_fileName) ?? CreateAppConfig();
            var data = File.ReadAllText(file);
            return JsonConvert.DeserializeObject<AppSettings>(data);
        }

        /// <summary>
        /// Save application settings to the file
        /// </summary>
        /// <param name="settings"></param>
        public void Save(AppSettings settings)
        {
            var data = JsonConvert.SerializeObject(settings);
            SaveFileToTheDisk(data);
        }

        /// <summary>
        /// Creates file if it not exists
        /// </summary>
        /// <returns></returns>
        private string CreateAppConfig()
        {
            var settings = new AppSettings();
            var data = JsonConvert.SerializeObject(settings);
            var filePath = Path.Combine(Environment.CurrentDirectory, _fileName);
            SaveFileToTheDisk(data);
            return filePath;
        }

        private void SaveFileToTheDisk(string data)
        {
            var filePath = Path.Combine(Environment.CurrentDirectory, _fileName);
            using (var sw = File.CreateText(filePath))
            {
                sw.Write(data);
            }
        }

        private string GetFilePath(string fileName)
        {
            var path = Path.Combine(Environment.CurrentDirectory, fileName);
            if (File.Exists(path))
            {
                return path;
            }

            return null;
        }
    }
}