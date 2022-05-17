using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.DTOs.Product
{
    public class MarkImageAsPrimaryDto
    {
        public Guid ProductId { get; set; }
        public Guid ImageId { get; set; }
    }
}
