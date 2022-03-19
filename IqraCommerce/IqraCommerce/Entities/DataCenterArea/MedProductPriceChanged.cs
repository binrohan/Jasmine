using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.DataCenterArea
{

    [Table("MedProductPriceChanged")]
    [Alias("mdpdctprchnd")]
    public class MedProductPriceChanged
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ProductId { get; set; }
        public string PriceLabel { get; set; }
        public double Price { get; set; }
        public string PriceLabelB { get; set; }
        public double PriceB { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
