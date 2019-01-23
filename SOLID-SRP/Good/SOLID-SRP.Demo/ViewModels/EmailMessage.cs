namespace SOLID_SRP.Demo.ViewModels
{
    /// <summary>
    /// Email message view models
    /// </summary>
    public class EmailMessage
    {
        /// <summary>
        /// Subject
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Body
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// MailTo address
        /// </summary>
        public string Email { get; set; }
    }
}