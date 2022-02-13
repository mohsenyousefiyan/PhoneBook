using FrameWork.Utilities.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Core.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infra.DAL.SQL.Users.Configs
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Tbl_Users");

            #region PropertyConfig

            builder.Property(x => x.FullName)
              .HasMaxLength(100)
              .IsRequired();


            builder.Property(x => x.UserName)
             .HasMaxLength(50)
             .IsRequired();

            builder.Property(x => x.Password)            
            .IsRequired();


            #endregion

            #region SeedData

            builder.HasData(new User { Id = 1, UserName = "admin", Password = SecurityHelper.SHA256_Hash("123"), FullName = "Administrator" });

            #endregion
        }
    }
}
