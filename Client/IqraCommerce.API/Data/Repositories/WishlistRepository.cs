using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Data.Repositories
{
    public class WishlistRepository : IWishlistRepository
    {
        private readonly DataContext _context;
        public WishlistRepository(DataContext context)
        {
            _context = context;
        }
    }
}