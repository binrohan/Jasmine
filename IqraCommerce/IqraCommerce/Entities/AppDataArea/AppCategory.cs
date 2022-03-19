using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.AppDataArea
{
    [Table("AppCategory")]
    [Alias("apctgr")]
    public partial class AppCategory : DropDownBaseEntity
    {
        public string ImagePath { get; set; }
    }
}
