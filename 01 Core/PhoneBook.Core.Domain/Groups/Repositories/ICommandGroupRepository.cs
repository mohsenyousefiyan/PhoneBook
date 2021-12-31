using FrameWork.Core.Domain.Data;
using PhoneBook.Core.Domain.Groups.Entities;

namespace PhoneBook.Core.Domain.Groups.Repositories
{
    public interface ICommandGroupRepository:ICommandRepository<Group, int>
    {
        Group Load(int id);
        Group LoadByUserName(string userName);
       
        void Add(Group entity);
    }
}
