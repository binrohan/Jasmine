using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.Entities;
using IqraCommerce.API.Params;

namespace IqraCommerce.API.Data.IRepositories
{
    public interface IAppReviewRepository
    {
        Task<int> CountAsync(AppReviewParam param);
        Task<IReadOnlyList<AppReview>> GetAppReviewsAsync(AppReviewParam param);
        Task<AppReview> GetAppReviewAsync(Guid id);
    }
}
