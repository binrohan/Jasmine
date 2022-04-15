using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace IqraCommerce.API.Data.Repositories
{

    public class UpazilaRepository : IUpazilaRepository
    {
        private readonly DataContext _context;
        public UpazilaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Upazila>> GetUpazilasByDistrictAsync(Guid districtId)
        {
            return await _context
                        .Upazila
                        .Where(u => !u.IsDeleted
                                    && u.IsVisible
                                    && u.DistrictId == districtId)
                        .OrderBy(u => u.Name)
                        .ToListAsync();
        }
    }
}