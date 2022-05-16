using System;
using AutoMapper;
using IqraCommerce.API.Constants;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.DTOs.Banner;
using IqraCommerce.API.DTOs.Category;
using IqraCommerce.API.DTOs.Contact;
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
            
            #region Unit
            CreateMap<Unit, UnitReturnDto>();
            #endregion Unit

            #region Banner
            CreateMap<Banner, BannerReturnDto>()
                .ForMember(dest => dest.ImageURL,
                            opt => opt.MapFrom(src =>  Config.AppSetting(Supdirs.directories, Subdirs.banner, Key.original) + src.ImageURL));
            #endregion Banner

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
            CreateMap<Product, ProductShortDto>();
            
            CreateMap<Product, HighlightedProductDto>()
            .ForMember(dest => dest.HighlightedImageURL,
                            opt => opt.MapFrom(src => Config.AppSetting(Supdirs.directories, Subdirs.productHighlight, Key.small) + src.HighlightedImageURL));
            CreateMap<Product, ProductDetailsDto>()
            .ForMember(dest => dest.Categories,
                            opt => opt.MapFrom(src => src.ProductCategories));

            CreateMap<Product, OrderProduct>()
                .ForMember(dest => dest.RefProductId,
                            opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Id,
                            opt => opt.Ignore());
            CreateMap<Product, OrderProduct>()
                .ForMember(dest => dest.Id,
                            opt => opt.Ignore());
            #endregion Product
        
            #region Address
            CreateMap<CustomerAddress, AddressReturnDto>();
            CreateMap<CustomerAddress, AddressDetailsDto>();
            CreateMap<AddressUpdateDto, CustomerAddress>();
            #endregion Address

            #region Customer
            CreateMap<RegisterDto, Customer>();
            CreateMap<Customer, CustomerAuthDto>();
            CreateMap<Customer, CustomerReturnDto>()
            .ForMember(dest => dest.ImageURL,
                            opt => opt.MapFrom(src => Config.AppSetting(Supdirs.directories, Subdirs.customer, Key.small) + src.ImageURL));
            CreateMap<CustomerAddress, ShippingAddress>()
                .ForMember(dest => dest.Id,
                            opt => opt.Ignore())
                .ForMember(dest => dest.RefAddressId,
                            opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.RefCustomerId,
                            opt => opt.MapFrom(src => src.CustomerId));
            #endregion Customer

            #region Complain
            CreateMap<ComplainCreateDto, Complain>();
            CreateMap<Complain, ComplainReturnDto>();
            #endregion Complain

            #region Promotion
            CreateMap<Promotion, PromotionReturnDto>()
            .ForMember(dest => dest.ImageURL,
                            opt => opt.MapFrom(src => Config.AppSetting(Supdirs.directories, Subdirs.Promotion, Key.original) + src.ImageURL));
            #endregion Promotion

            #region Festival
            CreateMap<Festival, FestivalReturnDto>();
            CreateMap<FestivalProduct, ProductShortDto>()
                .ForMember(dest => dest.Id,
                            opt => opt.MapFrom(src => src.Product.Id))
                .ForMember(dest => dest.Name,
                            opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.DisplayName,
                            opt => opt.MapFrom(src => src.Product.DisplayName))
                .ForMember(dest => dest.PackSize,
                            opt => opt.MapFrom(src => src.Product.PackSize))
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
            #endregion Festival
            
            #region Province
            CreateMap<Province, ProvinceReturnDto>();
            #endregion Privince

            #region District
            CreateMap<District, DistrictReturnDto>();
            #endregion District

            #region Upazila
            CreateMap<Upazila, UpazilaReturnDto>();
            #endregion Upazila

            #region Order
            CreateMap<Order, OrderShortDto>();
            CreateMap<Order, OrderDetailsDto>();
            CreateMap<Order, OrderReturnDto>();
            CreateMap<OrderPaymentDto, PaymentDto>()
            .ForMember(dest => dest.Cashback,
                            opt => opt.MapFrom(src => src.Cashback.CashbackAmount))
            .ForMember(dest => dest.CouponDiscount,
                            opt => opt.MapFrom(src => src.Coupon.Discount))
            .ForMember(dest => dest.CouponValue,
                            opt => opt.MapFrom(src => src.Coupon.Value))
            .ForMember(dest => dest.CouponMessage,
                            opt => opt.MapFrom(src => src.Coupon.Message));
            #endregion Order

            #region ShippingAddress
            CreateMap<ShippingAddress, ShippingAddressDto>();
            #endregion ShippingAddress

             #region OrderProduct
            CreateMap<OrderProduct, OrderProductReturnDto>();
            #endregion OrderProduct

            #region Device
            CreateMap<Device, DeviceReturnDto>();
            CreateMap<DeviceSetDto, Device>();
            #endregion Device

            #region Notificaion
            CreateMap<Notification, NotificationReturnDto>()
            .ForMember(dest => dest.IsRead,
                            opt => opt.MapFrom(src => src.CustomerNotifications.IsReadOnly))
            .ForMember(dest => dest.IconURL,
                            opt => opt.MapFrom(src => Config.AppSetting(Supdirs.directories, Subdirs.Notification, Key.original) + src.IconURL));
            #endregion Notificaion
        }
    }
}