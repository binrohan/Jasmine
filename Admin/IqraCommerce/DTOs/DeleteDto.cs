using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.DTOs
{
    public class DeleteDto
    {
        public Guid Id { get; set; }
        public Guid ActivityId { get; set; } = Guid.Empty;
    }
}
