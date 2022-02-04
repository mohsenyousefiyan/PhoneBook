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
        public ContactState State { get;private  set; }
        public List<ContactPhoneNumber> PhoneNumbers { get; set; }
        public List<ContactGroup> ContactGroups { get; set; }

        public Contact()
        {

        }
        public Contact(string firstName,string lastName)
        {
            FirstName = firstName;
            LastName= lastName;
            State = ContactState.Activated;
        }

        public void Delete()
        {
            State = ContactState.Deleted;
        }


        public void Disable()
        {
            State=  ContactState.Disabled;
        }
    }
}
