using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentExtraEdge.Model
{
    [Table("Users")]
    public class Users
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class UserLogin
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

    public class UserConstants
    {
        // fetch the user & its role from DB
        public static List<Users> Users = new()
            {
                    new Users(){ Email="edge@gmail.com",Password="edge@123"},

            };

    }
    
}
