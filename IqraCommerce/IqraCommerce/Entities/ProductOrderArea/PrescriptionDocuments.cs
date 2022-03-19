using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Entities.ProductOrderArea
{

    [Table("PrescriptionDocument")]
    [Alias("prscptn")]
    public partial class PrescriptionDocument : AppBaseEntity
    {
        public Guid CustomerId { get; set; }
        /// <summary>
        /// Image is uploaded with a Reference No and order is posted with the same Reference No.
        /// </summary>
        public string Reference { get; set; }
        public string FilePath { get; set; }
        public string IconPath { get; set; }
        public string MimeType { get; set; }
        public int Size { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Upload Prescription|Create Order|Upload In Order
        /// </summary>
        public string From { get; set; }
    }
}
