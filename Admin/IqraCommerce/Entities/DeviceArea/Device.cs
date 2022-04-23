using IqraBase.Data;
using IqraBase.Data.Entities;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.UserArea
{
    [Table("Device")]
    [Alias("device")]
    public partial class Device : DropDownBaseEntity
    {
        public Guid UserId { get; set; }
        public string AppName { get; set; }
        public string Language { get; set; }
        public string Platform { get; set; }
        public string UserAgent { get; set; }
        public bool HasAccess { get; set; }
        public string AccessType { get; set; }
    }
}
