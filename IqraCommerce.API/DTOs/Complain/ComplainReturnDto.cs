using System;
using System.ComponentModel.DataAnnotations;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.DTOs.Contact
{
    public class ComplainReturnDto
    {
        public Guid Id { get; set; }
        public ComplainType ComplainType { get; set; }
        public string Message { get; set; }
        public ComplainStatus ComplainStatus { get; set; }
    }
}