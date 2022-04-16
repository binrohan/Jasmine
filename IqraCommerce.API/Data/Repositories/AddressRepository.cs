using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace IqraCommerce.API.Data.Repositories
{

    public class AddressRepository : IAddressRepository
    {
        private readonly DataContext _context;
        public AddressRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<CustomerAddress> GetAddressAsync(Guid customerId, AddressType addressType)
        {
           return await _context
                            .CustomerAddress
                            .Where(ca => ca.CustomerId == customerId
                                         && ca.TypeOfAddress == addressType)
                            .Include(ca => ca.Province)
                            .Include(ca => ca.District)
                            .Include(ca => ca.Upazila)
                            .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CustomerAddress>> GetAddressesByCustomerAsync(Guid customerId)
        {
            return await _context
                            .CustomerAddress
                            .Where(ca => ca.CustomerId == customerId)
                            .Include(ca => ca.Province)
                            .Include(ca => ca.District)
                            .Include(ca => ca.Upazila)
                            .OrderBy(ca =>  ca.TypeOfAddress)
                            .ToListAsync();
        }

        public async Task<CustomerAddress> GetAddressAsync(Guid id)
        {
            return await _context
                            .CustomerAddress
                            .Where(ca => ca.Id == id)
                            .Include(ca => ca.Province)
                            .Include(ca => ca.District)
                            .Include(ca => ca.Upazila)
                            .SingleOrDefaultAsync();
        }
    }
}