using System;
using System.Collections.Generic;

namespace IqraCommerce.API.DTOs
{
    public class FestivalReturnDto
    {
         public Guid Id { get; set; }
        public string Name { get; set; }
        public int Rank { get; set; }
        public IEnumerable<ProductShortDto> Product { get; set; }
    }
}