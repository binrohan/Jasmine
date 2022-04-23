using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Data.IRepositories
{
    public interface IUpazilaRepository
    {
        Task<IEnumerable<Upazila>> GetUpazilasByDistrictAsync(Guid districtId);
    }
}