using System.ComponentModel.DataAnnotations;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.DTOs.Contact
{
    public class ComplainCreateDto : BaseCreateDto
    {
        public ComplainType ComplainType { get; set; }
        public string Message { get; set; }
    }
}