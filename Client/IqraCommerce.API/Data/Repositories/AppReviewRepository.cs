using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Entities;
using IqraCommerce.API.Params;
using Microsoft.EntityFrameworkCore;

namespace IqraCommerce.API.Data.Repositories
{

    public class AppReviewRepository : IAppReviewRepository
    {
        private readonly DataContext _context;
        public AppReviewRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> CountAsync(AppReviewParam param)
        {
            return await ParamEvaluator(param).CountAsync();
        }

        public async Task<AppReview> GetAppReviewAsync(Guid id)
        {
            return await _context.AppReview
                            .Include(r => r.Customer)
                            .FirstOrDefaultAsync(r => !r.IsDeleted && r.Id == id);
        }

        public async Task<IReadOnlyList<AppReview>> GetAppReviewsAsync(AppReviewParam param)
        {
            return await ParamEvaluator(param).Skip(param.Skip).Take(param.Take).ToListAsync();
        }

        private IQueryable<AppReview> ParamEvaluator(AppReviewParam param)
        {
            var query = _context.AppReview
                                .Where(r => (r.CustomerId == param.CustomerId
                                             || r.StateOfReview == ReviewState.Accepted) && !r.IsDeleted)
                                .Include(r => r.Customer)
                                .OrderByDescending(r => r.CreatedAt);
            
            return query;
        }
    }
}