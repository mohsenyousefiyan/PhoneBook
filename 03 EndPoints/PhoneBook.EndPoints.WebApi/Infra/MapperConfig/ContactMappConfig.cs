using AutoMapper;
using PhoneBook.Core.Domain.Contacts.Commands;
using PhoneBook.EndPoints.WebApi.Models.Contacts;
using System;

namespace PhoneBook.EndPoints.WebApi.Infra.MapperConfig
{
    public class ContactMappConfig:Profile
    {
        public ContactMappConfig()
        {
            CreateMap<ContactRegisterModel, ContactRegisterCommand>();
            CreateMap<ContactEditModel, ContactUpdateCommand>();
            //    .ForMember(dest => dest.Image, opt => opt.MapFrom(src => Convert.FromBase64String(src.Image)))
            //    .BeforeMap((src, dest) =>
            //{
            //    try { dest.Image = Convert.FromBase64String(src.Image); }
            //    catch { src.Image = null; }
            //});
        }
    }
}
