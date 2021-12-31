using FrameWork.Core.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook.Infra.DAL.SQL
{
    public class PhoneBookUnitOfWork: IUnitOfWork
    {
        private readonly PhoneBookCommandDbContext dbContext;

        public PhoneBookUnitOfWork(PhoneBookCommandDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Commit()
        {
            var entityForSave = GetEntityForSave();
            if (entityForSave != null && entityForSave.Count > 0)
                return dbContext.SaveChanges();
            return 0;
        }

        private List<EntityEntry> GetEntityForSave()
        {
            return dbContext.ChangeTracker
              .Entries()
              .Where(x => x.State == EntityState.Modified || x.State == EntityState.Added || x.State == EntityState.Deleted)
              .ToList();
        }
    }
}
