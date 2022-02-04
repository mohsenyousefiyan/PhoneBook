using FrameWork.Core.Domain.ApplicationServices.Commands;

namespace PhoneBook.Core.Domain.Contacts.Commands
{
    public class ContactDeleteCommand : ICommand
    {
        public int Id { get; set; }       
    }
}
