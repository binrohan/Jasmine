
using IqraBase.Data.Entities;
using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IqraCommerce.Data;

namespace EBonik.Data.Models.LocationArea
{
    
    public class DistrictModel : DropDownBaseModel
    {
        public int DistrictId { get; set; }
        public Guid ProvinceId { get; set; }
        public double ShippingCharge { get; set; }
        public double LowerBounderForMinShippingCharge { get; set; }
        public double MinShippingCharge { get; set; }
        public bool IsVisible { get; set; }
        public string Remarks { get; set; }
    }
}
