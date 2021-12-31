using FrameWork.Core.Domain.Entities;
using PhoneBook.Core.Domain.Groups.Enums;

namespace PhoneBook.Core.Domain.Groups.Entities
{
    public class Group:BaseEntity<int>
    {
        public string GroupName { get; set; }
        public GroupState State  { get; set; }
    }
}
