using IqraBase.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Models.ProductArea
{
    public class ProductImageModel : DropDownBaseModel
    {
        public string ReferenceId { get; set; }
        public Guid ProductId { get; set; }
        public string ImageURL { get; set; }
        public string IconURL { get; set; }
        public Guid PrimaryId { get; set; }
        public string MimeType { get; set; }
        public long Size { get; set; }
        public string Remarks { get; set; }

    }
}
