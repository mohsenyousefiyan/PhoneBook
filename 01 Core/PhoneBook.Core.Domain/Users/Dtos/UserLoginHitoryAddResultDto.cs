using System;

namespace PhoneBook.Core.Domain.Users.Dtos
{
    public class UserLoginHitoryAddResultDto
    {
        public  string AccessToken { get; set; }
        public DateTime ExpierDate { get; set; }        
    }
}
