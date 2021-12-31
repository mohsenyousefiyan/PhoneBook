using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Core.Domain.Groups.Enums
{
    public enum GroupState
    {
        [Display(Name = "فعال")]       
        Activated = 1,
        [Display(Name = "غیر فعال شده")]
        Disabled = 2,
        [Display(Name = "حذف شده")]
        Deleted = 3
    }
}
