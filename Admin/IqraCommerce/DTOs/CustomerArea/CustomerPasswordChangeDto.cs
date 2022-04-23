using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.DTOs.CustomerArea
{
    public class CustomerPasswordChangeDto
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string Remarks { get; set; }
    }
}
