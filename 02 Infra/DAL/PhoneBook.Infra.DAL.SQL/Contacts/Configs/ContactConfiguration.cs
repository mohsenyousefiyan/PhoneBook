using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Core.Domain.Contacts.Entities;
using PhoneBook.Core.Domain.Contacts.Enums;

namespace PhoneBook.Infra.DAL.SQL.Contacts.Configs
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Tbl_Contacts");

            #region PropertyConfig

            builder.Property(x => x.FirstName)
              .HasMaxLength(30)
              .IsRequired();


            builder.Property(x => x.LastName)
             .HasMaxLength(50)
             .IsRequired();


            builder.Property(x => x.State)
               .IsRequired()
               .HasColumnType("TinyInt");


            builder.HasQueryFilter(x => x.State != ContactState.Deleted);

           
            #endregion
        }
    }
}
