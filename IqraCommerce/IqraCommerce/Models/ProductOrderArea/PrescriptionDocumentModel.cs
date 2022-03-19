using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Models.ProductOrderArea
{
    public class PrescriptionDocumentModel : AppBaseModel
    {
        public Guid CustomerId { get; set; }
        /// <summary>
        /// OrderId is Used To Create Prescription Order if OrderId is not empty.
        /// </summary>
        public Guid OrderId { get; set; }
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
