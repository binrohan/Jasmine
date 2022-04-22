using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Data.IServices
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressDetailsDto>> GetAddressesByCustomerAsync(Guid customerId);
        Task<AddressDetailsDto> GetAddressAsync(Guid customerId, AddressType addressType);
    }
}