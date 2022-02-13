using FrameWork.Core.Domain.ApplicationServices.Commands;

namespace PhoneBook.Core.Domain.Users.Commands
{
    public class AddUserLoginHistoryCommand:ICommand
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ClientIPAddress { get; set; }
    }
}
