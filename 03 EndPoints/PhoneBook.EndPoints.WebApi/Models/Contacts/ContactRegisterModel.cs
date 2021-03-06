using FrameWork.EndPoints.WebApi.ViewModels.BaseViewModels;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.EndPoints.WebApi.Models.Contacts
{
    public class ContactRegisterModel : BaseInputModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
       
        public IFormFile Image { get; set; }
    }

}
