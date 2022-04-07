using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Data.IRepositories
{
    public interface ICustomerRepository
    {
         Task<Customer> FindByPhoneAsync(string phone);
    }
}