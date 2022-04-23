using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace IqraCommerce.API.Data.Repositories
{

    public class DeviceRepository : IDeviceRepository
    {
        private readonly DataContext _context;
        public DeviceRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Device> GetDeviceByUserAgentAsync(string userAgent)
        {
            return await _context
                        .Device
                        .FirstOrDefaultAsync(d => d.UserAgent == userAgent);
        }
    }
}