using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Data.IServices
{
    public interface ICustomerService
    {
        Task<IEnumerable<AddressReturnDto>> GetAddressesAsync(Guid customerId);
        Task<AddressReturnDto> GetAddressesAsync(Guid customerId, AddressType addressType);
        Task<int> UpdateAddressAsync(Guid customerId, AddressUpdateDto addressToUpdate);
        Task AddDueAsync(double amount, Guid customerId);
    }
}