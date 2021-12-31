using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Core.Domain.Contacts.Entities;

namespace PhoneBook.Infra.DAL.SQL.Contacts.Configs
{
    public class ContactGroupConfiguration : IEntityTypeConfiguration<ContactGroup>
    {
        public void Configure(EntityTypeBuilder<ContactGroup> builder)
        {
            builder.ToTable("Tbl_ContactGroups");

            #region PropertyConfig


            builder.HasOne(x => x.Group)
                .WithMany()
                .HasForeignKey(x => x.GroupId)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion
        }
    }
}
