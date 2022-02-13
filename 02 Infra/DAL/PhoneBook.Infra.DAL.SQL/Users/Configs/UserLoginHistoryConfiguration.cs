using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Core.Domain.Users.Entities;

namespace PhoneBook.Infra.DAL.SQL.Users.Configs
{
    public class UserLoginHistoryConfiguration : IEntityTypeConfiguration<UserLoginHistory>
    {
        public void Configure(EntityTypeBuilder<UserLoginHistory> builder)
        {
            builder.ToTable("Tbl_UserLoginHistory");

            #region PropertyConfig

            builder.Property(x => x.ClientIPAddress)
              .HasMaxLength(64)
              .IsRequired();
           
            #endregion
        }
    }
}
