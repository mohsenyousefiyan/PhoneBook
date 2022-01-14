using FrameWork.Core.Domain.Data;
using PhoneBook.Core.Domain.Contacts.Entities;

namespace PhoneBook.Core.Domain.Contacts.Repositories
{
    public interface IQueryConactRepository: IQueryRepository
    {
        Contact GetByFullName(string fullName); 
    }
}
