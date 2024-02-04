using Proiect_final.Models.Enums;

namespace Proiect_final.Models.Users
{
    public class User
    {
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public Role Role { get; set; } = Role.User;


        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }


    }
}
