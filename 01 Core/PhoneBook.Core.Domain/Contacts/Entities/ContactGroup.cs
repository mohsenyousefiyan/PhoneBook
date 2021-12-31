using FrameWork.Core.Domain.Data;
using FrameWork.Core.Domain.Entities;
using PhoneBook.Core.Domain.Groups.Entities;

namespace PhoneBook.Core.Domain.Contacts.Entities
{
    public class ContactGroup:BaseEntity<int>,IAuditLog
    {
        public int ContactId { get; set; }
        public int GroupId { get; set; }

        public Contact Contact  { get; set; }
        public Group Group  { get; set; }
    }
}
