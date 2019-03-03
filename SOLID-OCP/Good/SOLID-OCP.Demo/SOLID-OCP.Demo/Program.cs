using System;
using System.Runtime.InteropServices;
using Autofac;
using SOLID_OCP.Demo.Helpers;

namespace SOLID_OCP.Demo
{
    /// <summary>
    /// Open/Close Principle demo
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            #region Container creations and some resolvings
            var container = AutofacContainer.Create();
            var settingsManager = container.Resolve<AppSettingsManager>();
            #endregion

            var appSettings = settingsManager.Load();

            Logger.LogInfo($"ApplicationName:  {appSettings.ApplicationName}");
            Logger.LogInfo($"DefaultPageSize:  {appSettings.DefaultPageSize}");

            appSettings.ApplicationName = $"ApplicationName updated at {DateTime.Now}";
            appSettings.DefaultPageSize = 25;

            settingsManager.Save(appSettings);

            Logger.LogInfo($"ApplicationName:  {appSettings.ApplicationName}");
            Logger.LogInfo($"DefaultPageSize:  {appSettings.DefaultPageSize}");


        }
    }
}