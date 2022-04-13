using IqraCommerce.API.Data;

namespace IqraCommerce.API.DTOs
{
    public class ShippingAddressDto
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public int UpazilaId { get; set; }
        public AddressType TypeOfAddress { get; set; }
    }
}