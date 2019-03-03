using Demo.Package;
using SOLID_OCP.Demo.ViewModels;

namespace SOLID_OCP.Demo
{
    public class AppSettingsManager : AppSettingsManagerBase<AppSettings>
    {
        public AppSettingsManager(IConfigSerializer<AppSettings> serializer) 
            : base(serializer)
        {
        }

        /// <summary>
        /// File name for serialization
        /// </summary>
        public override string FileName
        {
            get { return "new-file-name-for-config.json"; }
        }
    }
}