using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Domain.Users.Entities;
using PhoneBook.Core.Domain.Users.Repositories;
using System.Linq;

namespace PhoneBook.Infra.DAL.SQL.Users.Repositories
{
    public class EfCommandUserRepository : ICommandUserRepository
    {
        private readonly PhoneBookCommandDbContext dbContext;

        public EfCommandUserRepository(PhoneBookCommandDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(User entity)
        {
            dbContext.Users.Add(entity);
        }

        public User Load(int id)
         =>dbContext.Users.Include(x => x.UserLoginHistories).Where(x => x.Id == id).FirstOrDefault();
       

        public User Load(string userName)
        => dbContext.Users.Include(x => x.UserLoginHistories).Where(x => x.UserName == userName).FirstOrDefault();
    }
}
