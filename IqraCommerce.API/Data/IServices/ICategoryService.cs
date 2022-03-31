using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Data.IServices
{
    public interface ICategoryService
    {
         Task<List<List<Category>>> GetChildrenWithProducts(Guid categoryId);
    }
}