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

        private readonly List<ContactPhoneNumber> phoneNumbers;
        private readonly List<ContactGroup> contactGroups;
        public IReadOnlyList<ContactPhoneNumber> PhoneNumbers => phoneNumbers.AsReadOnly();
        public IReadOnlyList<ContactGroup> ContactGroups => contactGroups.AsReadOnly();

        public Contact()
        {
            phoneNumbers = new List<ContactPhoneNumber>();
            contactGroups = new List<ContactGroup>();
        }
        public Contact(string firstName,string lastName)
        {
            phoneNumbers = new List<ContactPhoneNumber>();
            contactGroups = new List<ContactGroup>();

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
