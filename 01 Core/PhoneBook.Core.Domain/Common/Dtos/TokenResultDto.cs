using System;

namespace PhoneBook.Core.Domain.Common.Dtos
{
    public class TokenResultDto
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
