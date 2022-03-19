using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.DataCenterArea
{
    [Table("MedProduct")]
    [Alias("mdpdct")]
    public class MedProduct : DropDownBaseEntity
    {
        public double ProductId { get; set; }
        public string Strength { get; set; }
        public double GenericId { get; set; }
        public string GenericName { get; set; }
        /// <summary>
        /// $('.page-heading-1-l .h1-subtitle').text()
        /// </summary>
        public string Category { get; set; }
        public double CompanyId { get; set; }
        public string Company { get; set; }
        /// <summary>
        /// HTML
        /// </summary>
        public string Dosage { get; set; }
        /// <summary>
        /// HTML
        /// </summary>
        public string OverDosage { get; set; }
        /// <summary>
        /// HTML
        /// </summary>
        public string Storage { get; set; }
        public string PriceLabel { get; set; }
        public double Price { get; set; }
        public string PackUnit { get; set; }
        public double PackSize { get; set; }
        public double PackMRP { get; set; }
        /// <summary>
        /// console.log($('.sibling-aaa-title.d-block').parent().find('.d-block').find('a'))
        /// Id as json array.
        /// </summary>
        public string AlsoAs { get; set; }
        /// <summary>
        /// $('.container').children('.row').parent().html()
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Orginal Response From this url.
        /// </summary>
        public string HTML { get; set; }
        public string Url { get; set; }
    }
}
