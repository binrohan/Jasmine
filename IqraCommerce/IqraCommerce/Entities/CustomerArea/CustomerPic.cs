using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.CustomerArea
{
    [Table("CustomerPic")]
    [Alias("cstmrp")]
    public partial class CustomerPic : AppBaseEntity
    {
        public Guid CustomerId { get; set; }
        public string FilePath { get; set; }
        public string IconPath { get; set; }
        public string MimeType { get; set; }
        public int Size { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
