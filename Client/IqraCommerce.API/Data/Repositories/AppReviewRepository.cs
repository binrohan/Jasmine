using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Entities;
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
    }
}