using FrameWork.Core.Domain.ApplicationServices.Commands;

namespace PhoneBook.Core.Domain.Contacts.Commands
{
    public class ContactRegisterCommand:ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Image { get; set; }
    }
}
