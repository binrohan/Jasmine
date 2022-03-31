using System;
using AutoMapper;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.DTOs.Banner;
using IqraCommerce.API.DTOs.Category;
using IqraCommerce.API.DTOs.Contact;
using IqraCommerce.API.DTOs.Notice;
using IqraCommerce.API.DTOs.Product;
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

            #region Unit
            CreateMap<Unit, UnitReturnDto>();
            #endregion Unit

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
            CreateMap<ProductCategory, CategoryShortDto>()
            .ForMember(dest => dest.Name,
                            opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.Id,
                            opt => opt.MapFrom(src => src.Category.Id));
            CreateMap<Category, CategoryShortDto>();
            #endregion Category

            #region Product
            CreateMap<Product, ProductDetailsDto>()
            .ForMember(dest => dest.ImageURL, 
                            opt => opt.MapFrom(src => "/Contents/Images/Product/Original/" + src.ImageURL))
            .ForMember(dest => dest.Unit, 
                            opt => opt.MapFrom(src => src.Unit.Name))
            .ForMember(dest => dest.Brand,
                            opt => opt.MapFrom(src => src.Brand.Name))
            .ForMember(dest => dest.Categories,
                            opt => opt.MapFrom(src => src.ProductCategories));
            #endregion Product
        }
    }
}