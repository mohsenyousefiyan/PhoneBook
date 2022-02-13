using FrameWork.Core.Domain.Data;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Domain.Contacts.Entities;
using PhoneBook.Core.Domain.Groups.Entities;
using PhoneBook.Core.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.Infra.DAL.SQL
{
    public class PhoneBookCommandDbContext:DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactPhoneNumber> ContactPhoneNumbers { get; set; }
        public DbSet<ContactGroup> ContactGroups { get; set; }
        public DbSet<User> Users { get; set; }

        public PhoneBookCommandDbContext(DbContextOptions options) : base(options)
        {
        }

        //public PhoneBookCommandDbContext()
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)           
                optionsBuilder.UseSqlServer("Password=1;User=sa;Initial Catalog=PhoneBookDB;Data Source=.");                           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);


            var entitiesAssembly = typeof(Group).Assembly;
            RegisterAuditLog(modelBuilder, entitiesAssembly);
        }

        public override int SaveChanges()
        {
            SetValueForLastEditDate();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            SetValueForLastEditDate();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            SetValueForLastEditDate();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetValueForLastEditDate();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void RegisterAuditLog(ModelBuilder modelBuilder, params Assembly[] assemblies)
        {
            IEnumerable<Type> types = assemblies.SelectMany(a => a.GetExportedTypes())
               .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic && typeof(IAuditLog).IsAssignableFrom(c));

            foreach (Type type in types)
            {
                modelBuilder.Entity(type).Property<DateTime>("CreationDate")
                    .HasDefaultValueSql("GetDate()")
                    .ValueGeneratedOnAdd();

                modelBuilder.Entity(type).Property<DateTime>("LastEditDate")
                    .HasDefaultValueSql("GetDate()");
            }
        }
        private void SetValueForLastEditDate()
        {
            var modifiedEntities = ChangeTracker.Entries()
                    .Where(p => typeof(IAuditLog).IsAssignableFrom(p.Entity.GetType()) && p.State == EntityState.Modified)
                    .ToList();

            foreach (var item in modifiedEntities)
                Entry(item.Entity).Property("LastEditDate").CurrentValue = DateTime.Now;
        }
    }

    public class PhoneBookQueryDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public PhoneBookQueryDbContext(DbContextOptions options) : base(options)
        {
        }
        //public PhoneBookQueryDbContext()
        //{

        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);                        
        }
    }
}
