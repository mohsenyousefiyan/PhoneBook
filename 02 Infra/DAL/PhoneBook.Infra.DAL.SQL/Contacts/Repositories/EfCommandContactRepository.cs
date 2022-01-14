using PhoneBook.Core.Domain.Contacts.Entities;
using PhoneBook.Core.Domain.Contacts.Repositories;
using System.Linq;

namespace PhoneBook.Infra.DAL.SQL.Contacts.Repositories
{
    public class EfCommandContactRepository : ICommandContactRepository
    {
        private readonly PhoneBookCommandDbContext dbContext;

        public EfCommandContactRepository(PhoneBookCommandDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Contact entity)
        {
            dbContext.Contacts.Add(entity);
        }

        public Contact Load(int id)=>dbContext.Contacts.FirstOrDefault(x=>x.Id == id);   
        
    }
}
