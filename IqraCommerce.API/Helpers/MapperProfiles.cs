using System;
using AutoMapper;
using IqraCommerce.API.DTOs.Banner;
using IqraCommerce.API.DTOs.Brand;
using IqraCommerce.API.DTOs.Category;
using IqraCommerce.API.DTOs.Contact;
using IqraCommerce.API.DTOs.Notice;
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

            #region Banner
            CreateMap<Banner, BannerReturnDto>()
                .ForMember(dest => dest.ImageURL, 
                            opt => opt.MapFrom(src => "/Contents/Images/Product/Icon/" + src.ImageURL));
            #endregion Banner

            #region Notice
            CreateMap<Notice, NoticeReturnDto>();
            #endregion Notice

            #region Category
            CreateMap<Category, HomeCategoryDto>();
            #endregion Category
        }
    }
}