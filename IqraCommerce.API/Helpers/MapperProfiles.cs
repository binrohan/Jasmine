using System;
using AutoMapper;
using IqraCommerce.API.DTOs.Brand;
using IqraCommerce.API.DTOs.Contact;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Helpers
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            #region Contact
            CreateMap<ContactCreateDto, Contact>()
                .ForMember(dest => dest.Status,
                            opt => opt.MapFrom(src => "New"));
            CreateMap<Contact, ContactReturnDto>();
            #endregion Contact

            #region Brand
            CreateMap<Brand, BrandReturnDto>();
            #endregion Brand
        }
    }
}