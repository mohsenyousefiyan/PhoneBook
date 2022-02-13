using FrameWork.Core.Domain.Data;
using FrameWork.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace PhoneBook.Core.Domain.Users.Entities
{
    public class User:BaseEntity<int>, IAuditLog
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        private List<UserLoginHistory> userLoginHistories;
        public IReadOnlyList<UserLoginHistory> UserLoginHistories => userLoginHistories.AsReadOnly();

        public User()
        {
            userLoginHistories = new List<UserLoginHistory>();
        }

        public void AddLoginHistory(string clientIPAddress)
        {
            var history = new UserLoginHistory
            {
                ClientIPAddress = clientIPAddress,
                LoginDate = DateTime.Now
            };
            userLoginHistories.Add(history);
        }
    }
}
