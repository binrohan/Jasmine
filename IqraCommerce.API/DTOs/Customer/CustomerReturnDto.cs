using System;

namespace IqraCommerce.API.DTOs
{
    public class CustomerReturnDto
    {
        public Guid Id { get; set; }
        public string ImageURL { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string DueAmount { get; set; }
        public string Cashback { get; set; }
        public string Token { get; set; }
    }
}