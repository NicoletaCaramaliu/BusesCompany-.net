using Proiect_final.Models.Enums;

namespace Proiect_final.Models.Users
{
    public class UserDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        
        //role
        public Role Role { get; set; }

    }
}
