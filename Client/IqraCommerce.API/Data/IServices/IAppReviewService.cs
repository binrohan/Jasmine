using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.Entities;
using IqraCommerce.API.Helpers;

namespace IqraCommerce.API.Data.IRepositories
{
    public interface IAppReviewService
    {
        Task<Pagination<AppReviewReturnDto>> GetAppReivewsAsync(AppReviewParamDto paramDto);
    }
}
