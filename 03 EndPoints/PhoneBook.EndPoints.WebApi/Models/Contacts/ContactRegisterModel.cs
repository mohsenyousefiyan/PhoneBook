using FrameWork.EndPoints.WebApi.ViewModels.BaseViewModels;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.EndPoints.WebApi.Models.Contacts
{
    public class ContactRegisterModel : BaseInputModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Image { get; set; }
    }

}
