using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Models.GalleryArea
{
    [Table("GalleryDocument")]
    [Alias("glrydcmnts")]
    public partial class GalleryDocumentModel : AppBaseModel
    {
        public Guid GalleryId { get; set; }
        public string FilePath { get; set; }
        public string IconPath { get; set; }
        public string MimeType { get; set; }
        public int Size { get; set; }
        public string Name { get; set; }
    }
}
