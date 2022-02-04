using FrameWork.Core.Domain.ApplicationServices.Commands;

namespace PhoneBook.Core.Domain.Contacts.Commands
{
    public class ContactUpdateCommand:ICommand
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
