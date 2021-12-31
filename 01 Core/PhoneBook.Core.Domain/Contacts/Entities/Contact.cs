using FrameWork.Core.Domain.Data;
using FrameWork.Core.Domain.Entities;
using PhoneBook.Core.Domain.Contacts.Enums;
using System.Collections.Generic;

namespace PhoneBook.Core.Domain.Contacts.Entities
{
    public class Contact:BaseEntity<int>,IAuditLog
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Image { get; set; }
        public ContactState State { get; set; }
        public List<ContactPhoneNumber> PhoneNumbers { get; set; }
        public List<ContactGroup> ContactGroups { get; set; }
    }
}
