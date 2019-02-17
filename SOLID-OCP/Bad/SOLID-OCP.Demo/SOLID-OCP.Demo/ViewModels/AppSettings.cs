namespace SOLID_OCP.Demo.ViewModels
{
    /// <summary>
    /// Current application settings
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Default page size for pagination
        /// </summary>
        public int DefaultPageSize { get; set; } = 10;

        /// <summary>
        /// Application name for reports mentions
        /// </summary>
        public string ApplicationName { get; set; } = "Demo for SOLID OCP";
    }
}
