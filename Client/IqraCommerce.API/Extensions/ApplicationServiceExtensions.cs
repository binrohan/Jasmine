using System.Linq;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Data.IServices;
using IqraCommerce.API.Data.Repositories;
using IqraCommerce.API.Data.Services;
using IqraCommerce.API.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using static IqraCommerce.API.Data.IRepositories.IGenericRepository;

namespace IqraCommerce.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // services.AddSingleton<IResponseCacheService, ResponseCacheService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IOTPService, OTPService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IFestivalService, FestivalService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICouponRedeemHistoryService, CouponRedeemHistoryService>();
            services.AddScoped<ICouponService, CouponService>();
            services.AddScoped<ICashbackService, CashbackService>();
            services.AddScoped<ICashbackHistoryService, CashbackHistoryService>();
            services.AddScoped<ICashbackRegisterService, CashbackRegisterService>();
            services.AddScoped<IAquiredOfferService, AquiredOfferService>();
            services.AddScoped<IPaymentHistoryService, PaymentHistoryService>();
            services.AddScoped<IOrderProductService, OrderProductService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IAppReviewService, AppReviewService>();
            services.AddScoped<IReviewService, ReviewService>();
            // services.AddScoped<IOrderService, OrderService>();
            // services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUIRepository, UIRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IPromotionRepository, PromotionRepository>();
            services.AddScoped<IFestivalRepository, FestivalRepository>();
            services.AddScoped<IWishlistRepository, WishlistRepository>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IUpazilaRepository, UpazilaRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IDeviceRepository, DeviceRepository>();
            services.AddScoped<ICouponRepository, CouponRepository>();
            services.AddScoped<ICouponRedeemHistoryRepository, CouponRedeemHistoryRepository>();
            services.AddScoped<ICashbackRepository, CashbackRepository>();
            services.AddScoped<ICashbackHistoryRepository, CashbackHistoryRepository>();
            services.AddScoped<ICashbackRegisterRepository, CashbackRegisterRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<ICustomerNotificationRepository, CustomerNotificationRepository>();
            services.AddScoped<IAppReviewRepository, AppReviewRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new ApiResponse(406, new {Errors = errors}, "One or more validation failed");
                    

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;
        }
    }
}