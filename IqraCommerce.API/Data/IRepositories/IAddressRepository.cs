using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Data.IRepositories
{
    public interface IAddressRepository
    {
         Task<IEnumerable<CustomerAddress>> GetAddressesByCustomerAsync(Guid customerId);
          Task<CustomerAddress> GetAddressAsync(Guid customerId, AddressType addressType);
          Task<CustomerAddress> GetAddressAsync(Guid addressId);
    }
}