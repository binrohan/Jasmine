
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
    
    public class UpazilaModel : DropDownBaseModel
    {
        public int UpazilaId { get; set; }
        public Guid ProvinceId { get; set; }
        public Guid DistrictId { get; set; }
        public bool IsVisible { get; set; }
        public string Remarks { get; set; }
    }
}
