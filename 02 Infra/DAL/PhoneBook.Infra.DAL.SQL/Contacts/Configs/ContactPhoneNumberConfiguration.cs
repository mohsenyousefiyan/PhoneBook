using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Core.Domain.Contacts.Entities;

namespace PhoneBook.Infra.DAL.SQL.Contacts.Configs
{
    public class ContactPhoneNumberConfiguration : IEntityTypeConfiguration<ContactPhoneNumber>
    {
        public void Configure(EntityTypeBuilder<ContactPhoneNumber> builder)
        {
            builder.ToTable("Tbl_ContactPhoneNumbers");

            #region PropertyConfig

            builder.Property(x => x.PhoneNumber)
              .HasMaxLength(30)
              .IsUnicode(false)
              .IsRequired();


            #endregion
        }
    }
}
