using System.ComponentModel.DataAnnotations;

namespace IqraCommerce.API.DTOs.Contact
{
    public class ContactCreateDto : BaseCreateDto
    {
        public string Name { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        public string Mobile { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage = "Message is required")]
        public string Massege { get; set; }
    }
}