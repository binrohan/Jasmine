using System;
using System.Collections.Generic;

namespace IqraCommerce.API.DTOs.Category
{
    public class CategoryDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IList<CategoryDto> ChildCategores { get; set; }
    }
}