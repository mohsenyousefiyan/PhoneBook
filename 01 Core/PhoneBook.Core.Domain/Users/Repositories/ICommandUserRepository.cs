using FrameWork.Core.Domain.Data;
using PhoneBook.Core.Domain.Users.Entities;

namespace PhoneBook.Core.Domain.Users.Repositories
{
    public interface ICommandUserRepository : ICommandRepository<User, int>
    {
        User Load(int id);
        User Load(string userName);

        void Add(User entity);
    }
}
