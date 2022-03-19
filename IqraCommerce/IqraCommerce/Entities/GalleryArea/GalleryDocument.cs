using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Entities.GalleryArea
{

    [Table("GalleryDocument")]
    [Alias("glrydcmnts")]
    public partial class GalleryDocument : AppBaseEntity
    {
        public Guid GalleryId { get; set; }
        public string FilePath { get; set; }
        public string IconPath { get; set; }
        public string MimeType { get; set; }
        public int Size { get; set; }
        public string Name { get; set; }
    }
}
