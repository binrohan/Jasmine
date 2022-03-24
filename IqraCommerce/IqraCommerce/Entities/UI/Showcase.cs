using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.UI
{
    [Table("Showcase")]
    [Alias("showcase")]
    public partial class Showcase : DropDownBaseEntity
    {
        public string ImageURL { get; set; }
        public double Rank { get; set; }
        public bool IsVisible { get; set; }
    }
}
