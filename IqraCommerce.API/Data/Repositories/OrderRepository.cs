using IqraCommerce.API.Data.IRepositories;

namespace IqraCommerce.API.Data.Repositories
{

    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        public OrderRepository(DataContext context)
        {
            _context = context;
        }
    }
}