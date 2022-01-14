using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Domain.Contacts.Entities;
using PhoneBook.Core.Domain.Contacts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infra.DAL.SQL.Contacts.Repositories
{
    public class EfQueryConactRepository : IQueryConactRepository
    {
        private readonly PhoneBookQueryDbContext dbContext;

        public EfQueryConactRepository(PhoneBookQueryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Contact GetByFullName(string fullName)=>dbContext.Contacts.AsNoTracking().FirstOrDefault(x => x.FirstName + " " + x.LastName == fullName);
        
    }
}
