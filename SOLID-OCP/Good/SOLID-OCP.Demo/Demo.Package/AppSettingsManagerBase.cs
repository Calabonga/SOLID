using System;
using System.IO;

namespace Demo.Package
{
    /// <summary>
    /// Notification manager
    /// </summary>
    public abstract class AppSettingsManagerBase<T> where T: class, new()
    {
        private readonly IConfigSerializer<T> _serializer;
        private readonly string _fileName = "app-config.json";

        public AppSettingsManagerBase(IConfigSerializer<T> serializer)
        {
            _serializer = serializer;
        }

        /// <summary>
        /// File name for serialization
        /// </summary>
        public virtual string FileName
        {
            get { return _fileName; }
        }


        /// <summary>
        /// Load and deserialize data from configuration
        /// </summary>
        /// <returns></returns>
        public T Load()
        {
            var file = GetFilePath(FileName) ?? CreateAppConfig();
            var data = File.ReadAllText(file);
            return _serializer.Deserialize(data);
        }

        /// <summary>
        /// Save application settings to the file
        /// </summary>
        /// <param name="settings"></param>
        public void Save(T settings)
        {
            var data = _serializer.Serialize(settings);
            SaveFileToTheDisk(data);
        }

        /// <summary>
        /// Creates file if it not exists
        /// </summary>
        /// <returns></returns>
        private string CreateAppConfig()
        {
            var settings = new T();
            var data = _serializer.Serialize(settings);
            var filePath = Path.Combine(Environment.CurrentDirectory, FileName);
            SaveFileToTheDisk(data);
            return filePath;
        }

        private void SaveFileToTheDisk(string data)
        {
            var filePath = Path.Combine(Environment.CurrentDirectory, FileName);
            using (var sw = File.CreateText(filePath))
            {
                sw.Write(data);
            }
        }

        private string GetFilePath(string fileName)
        {
            var path = Path.Combine(Environment.CurrentDirectory, fileName);
            return File.Exists(path) ? path : null;
        }
    }
}