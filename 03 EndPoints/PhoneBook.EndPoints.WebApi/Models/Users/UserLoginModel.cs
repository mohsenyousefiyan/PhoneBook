using System.ComponentModel.DataAnnotations;

namespace PhoneBook.EndPoints.WebApi.Models.Users
{
    public class UserLoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
