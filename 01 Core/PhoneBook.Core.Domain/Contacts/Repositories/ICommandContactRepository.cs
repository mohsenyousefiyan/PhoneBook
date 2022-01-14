using FrameWork.Core.Domain.Data;
using PhoneBook.Core.Domain.Contacts.Entities;

namespace PhoneBook.Core.Domain.Contacts.Repositories
{
    public interface ICommandContactRepository: ICommandRepository<Contact, int>
    {
        Contact Load(int id);
        
        void Add(Contact entity);
    }
}
