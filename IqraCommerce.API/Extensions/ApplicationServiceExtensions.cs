using System.Linq;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Data.Repositories;
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
            // services.AddScoped<ITokenService, TokenService>();
            // services.AddScoped<IOrderService, OrderService>();
            // services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUIRepository, UIRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // services.AddScoped<IProductRepository, ProductRepository>();
            // services.AddScoped<IBrandRepository, BrandRepository>();
            // services.AddScoped<IBasketRepository, BasketRepository>();

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