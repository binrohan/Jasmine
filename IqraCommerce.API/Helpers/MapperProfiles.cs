using System;
using AutoMapper;
using IqraCommerce.API.Constants;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.DTOs.Banner;
using IqraCommerce.API.DTOs.Category;
using IqraCommerce.API.DTOs.Contact;
using IqraCommerce.API.DTOs.Notice;
using IqraCommerce.API.Entities;
using Microsoft.Extensions.Configuration;

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
                            opt => opt.MapFrom(src =>  Config.AppSetting(Dirs.banner, ImageSize.original) + src.ImageURL));
            #endregion Banner

            #region Notice
            CreateMap<Notice, NoticeReturnDto>();
            #endregion Notice

            #region Category
            CreateMap<Category, HomeCategoryDto>();
            CreateMap<Category, CategoryShortDto>();
            CreateMap<Category, CategoryWithProductDto>()
                .ForMember(dest => dest.Products,
                                opt => opt.MapFrom(src => src.ProductCategories));
            #endregion Category

            #region ProductCategory
            CreateMap<ProductCategory, CategoryShortDto>()
                .ForMember(dest => dest.Name,
                                opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Id,
                                opt => opt.MapFrom(src => src.Category.Id));

            CreateMap<ProductCategory, ProductShortDto>()
                .ForMember(dest => dest.Id,
                            opt => opt.MapFrom(src => src.Product.Id))
                .ForMember(dest => dest.Name,
                            opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.DisplayName,
                            opt => opt.MapFrom(src => src.Product.DisplayName))
                .ForMember(dest => dest.PackSize,
                            opt => opt.MapFrom(src => src.Product.PackSize))
                .ForMember(dest => dest.ImageURL,
                            opt => opt.MapFrom(src =>  Config.AppSetting(Dirs.banner, ImageSize.small) + src.Product.ImageURL))
                .ForMember(dest => dest.CurrentPrice,
                            opt => opt.MapFrom(src => src.Product.CurrentPrice))
                .ForMember(dest => dest.OriginalPrice,
                            opt => opt.MapFrom(src => src.Product.OriginalPrice))
                .ForMember(dest => dest.DiscountedPrice,
                            opt => opt.MapFrom(src => src.Product.DiscountedPrice))
                .ForMember(dest => dest.DiscountedPercentage,
                            opt => opt.MapFrom(src => src.Product.DiscountedPercentage))
                .ForMember(dest => dest.StockUnit,
                            opt => opt.MapFrom(src => src.Product.StockUnit))
                .ForMember(dest => dest.Rank,
                            opt => opt.MapFrom(src => src.Product.Rank));
            #endregion ProductCategory

            #region CategoryDto
            CreateMap<CategoryDto, CategoryWithProductDto>();
            #endregion Category

            #region Product
            CreateMap<Product, ProductShortDto>()
            .ForMember(dest => dest.ImageURL,
                            opt => opt.MapFrom(src => Config.AppSetting(Dirs.product, ImageSize.small) + src.ImageURL));
            CreateMap<Product, HighlightedProductDto>()
            .ForMember(dest => dest.HighlightedImageURL,
                            opt => opt.MapFrom(src => Config.AppSetting(Dirs.productHighlight, ImageSize.small) + src.HighlightedImageURL));
            CreateMap<Product, ProductDetailsDto>()
            .ForMember(dest => dest.ImageURL,
                            opt => opt.MapFrom(src => Config.AppSetting(Dirs.product, ImageSize.original) + src.ImageURL))
            .ForMember(dest => dest.Categories,
                            opt => opt.MapFrom(src => src.ProductCategories));
            #endregion Product
        }
    }
}