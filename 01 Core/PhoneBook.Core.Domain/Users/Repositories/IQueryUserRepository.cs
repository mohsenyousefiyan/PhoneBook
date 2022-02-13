using FrameWork.Core.Domain.Data;
using PhoneBook.Core.Domain.Users.Entities;

namespace PhoneBook.Core.Domain.Users.Repositories
{
    public interface IQueryUserRepository : IQueryRepository
    {
        User GetByUserName(string userName);
    }
}
