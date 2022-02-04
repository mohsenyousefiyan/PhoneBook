using FrameWork.EndPoints.WebApi.ViewModels.BaseViewModels;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.EndPoints.WebApi.Models.Contacts
{
    public class ContactEditModel : BaseInputModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
    }

}
