using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.DTOs
{
    public class ImageUploadDto
    {
        public Guid Id { get; set; }
        public IFormFile Img { get; set; }
        public Guid ActivityId { get; set; }
    }

    public class FileDto
    {
        public bool IsFile { get; set; }
        public IFormFile File { get; set; }
    }
}
