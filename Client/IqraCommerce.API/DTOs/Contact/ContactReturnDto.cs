namespace IqraCommerce.API.DTOs.Contact
{
    public class ContactReturnDto : BaseDto
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Massege { get; set; }
        public string Status { get; set; }
    }
}