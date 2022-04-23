using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace IqraCommerce.API.Data.Repositories
{

    public class DistrictRepository : IDistrictRepository
    {
        private readonly DataContext _context;
        public DistrictRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<District>> GetDistrictsByProvinceAsync(Guid provinceId)
        {
            return await _context
                        .District
                        .Where(d => !d.IsDeleted
                                    && d.IsVisible
                                    && d.ProvinceId == provinceId)
                        .OrderBy(d => d.Name)
                        .ToListAsync();
        }
    }
}