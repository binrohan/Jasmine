using System.ComponentModel.DataAnnotations;

namespace IqraCommerce.API.DTOs
{
    public class BugDto
    {
        [Required]
        public int Id { get; set; }
        
        [MinLength(4)]
        public string Name { get; set; }
    }
}