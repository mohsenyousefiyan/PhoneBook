using FrameWork.Core.Domain.Data;
using FrameWork.Core.Domain.Entities;
using PhoneBook.Core.Domain.Contacts.Enums;

namespace PhoneBook.Core.Domain.Contacts.Entities
{
    public class ContactPhoneNumber:BaseEntity<int>,IAuditLog
    {        
        public int ContactId { get; set; }
        public PhoneNumberType PhoneNumberType { get; set; }
        public string PhoneNumber { get; set; }

        public Contact Contact { get; set; }
    }
}
