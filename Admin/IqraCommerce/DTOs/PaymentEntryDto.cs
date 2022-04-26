using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.DTOs
{
    public class PaymentEntryDto
    {
        public double Amount { get; set; }
        public string Reference { get; set; }
        public string Remarks { get; set; }
        public Guid ActivityId { get; set; } = Guid.Empty;
        public Guid Id { get; set; }
    }
}
