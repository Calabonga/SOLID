namespace SOLID_SRP.Demo.Models
{
    /// <summary>
    /// User
    /// </summary>
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public bool IsAdmin { get; set; }
    }
}
