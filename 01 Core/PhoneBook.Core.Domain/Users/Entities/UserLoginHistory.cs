using FrameWork.Core.Domain.Entities;
using System;

namespace PhoneBook.Core.Domain.Users.Entities
{
    public class UserLoginHistory:BaseEntity<Int64>
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime LoginDate { get; set; }
        public string ClientIPAddress { get; set; }
    }
}
