using System;
using System.Collections;
using System.Collections.Generic;

namespace IqraCommerce.API.DTOs
{
    public class CustomerReturnDto
    {
        public Guid Id { get; set; }
        public string ImageURL { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public double DueAmount { get; set; }
        public double Cashback { get; set; }
        public IEnumerable<AddressReturnDto> Addresses { get; set; }
    }
}