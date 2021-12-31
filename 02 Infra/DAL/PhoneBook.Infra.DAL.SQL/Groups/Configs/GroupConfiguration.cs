using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Core.Domain.Groups.Entities;
using PhoneBook.Core.Domain.Groups.Enums;

namespace PhoneBook.Infra.DAL.SQL.Groups.Configs
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Tbl_Groups");

            #region PropertyConfig

            builder.Property(x => x.GroupName)
              .HasMaxLength(50)
              .IsRequired();


            builder.Property(x => x.State)
               .IsRequired()
               .HasColumnType("TinyInt");

            builder.HasQueryFilter(x => x.State != GroupState.Deleted);


            builder.HasIndex(x => x.GroupName)
                .HasDatabaseName("IX_GroupName");

            builder.HasData(new Group { Id = 1, GroupName = "Group01", State = GroupState.Activated },
                            new Group { Id = 2, GroupName = "Group02", State = GroupState.Activated });

            #endregion
        }
    }
}
