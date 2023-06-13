namespace Data.Models.ViewModels
{
    public class UserView
    {
        public Guid Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public Guid IdRole { get; set; }
        public string RoleName { get; set; }
    }
}
