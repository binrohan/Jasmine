using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Data.IRepositories
{
    public interface IUIRepository
    {
         Task<IEnumerable<Banner>> GetBannersAsync(BannerType bannerType = BannerType.MainBanner);
    }
}