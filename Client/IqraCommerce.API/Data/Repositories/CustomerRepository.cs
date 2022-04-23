using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace IqraCommerce.API.Data.Repositories
{

    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;
        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Customer> FindByPhoneAsync(string phone)
        {
            return await _context
                            .Customer
                            .Where(c => c.Phone == phone)
                            .FirstOrDefaultAsync();
        }

        public async Task<Customer> GetCustomerAsync(Guid id)
        {
            return await _context
                            .Customer
                            .Where(c => c.Id == id)
                            .Include(c => c.Addresses.OrderBy(a => a.TypeOfAddress))
                            .FirstOrDefaultAsync();
        }
    }
}