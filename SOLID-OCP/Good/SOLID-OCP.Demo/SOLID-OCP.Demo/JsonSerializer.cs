using System;
using Demo.Package;
using Newtonsoft.Json;
using SOLID_OCP.Demo.ViewModels;

namespace SOLID_OCP.Demo
{
    public class JsonSerializer: IConfigSerializer<AppSettings>
    {
        public AppSettings Deserialize(string data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            return JsonConvert.DeserializeObject<AppSettings>(data);
        }

        public string Serialize(AppSettings obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            return JsonConvert.SerializeObject(obj);
        }
    }
}