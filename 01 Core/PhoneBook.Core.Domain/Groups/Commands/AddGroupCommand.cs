using FrameWork.Core.Domain.ApplicationServices.Commands;

namespace PhoneBook.Core.Domain.Groups.Commands
{
    public class AddGroupCommand:ICommand
    {
        public string GroupName { get; set; }
    }
}
