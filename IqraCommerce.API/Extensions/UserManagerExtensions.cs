using System.Security.Claims;
using System.Threading.Tasks;
using IqraCommerce.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IqraCommerce.API.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<Customer> FindByPhoneFromClaimsPrinciple(this UserManager<Customer> input, ClaimsPrincipal user)
        {
            var phone = user.FindFirstValue(ClaimTypes.MobilePhone);

            return await input.Users.SingleOrDefaultAsync(x => x.Phone == phone);
        }
    }
}