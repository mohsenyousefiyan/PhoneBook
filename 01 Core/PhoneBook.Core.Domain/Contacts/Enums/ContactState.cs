using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Core.Domain.Contacts.Enums
{
    public enum ContactState
    {
        [Display(Name = "فعال")]
        Activated = 1,
        [Display(Name = "غیر فعال شده")]
        Disabled = 2,
        [Display(Name = "حذف شده")]
        Deleted = 3
    }
}
