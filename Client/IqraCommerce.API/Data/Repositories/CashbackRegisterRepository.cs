using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace IqraCommerce.API.Data.Repositories
{

    public class CashbackRegisterRepository : ICashbackRegisterRepository
    {
        private readonly DataContext _context;
        public CashbackRegisterRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<CashbackRegister> GetByOrderIdAsync(Guid id)
        {
            return await _context
                                .CashbackRegister
                                .FirstOrDefaultAsync(c => c.OrderId == id);
        }
    }
}