using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.ProductOrderArea
{
    [Table("ErrorOeder")]
    [Alias("errodr")]
    public partial class ErrorOeder : AppBaseEntity
    {
        public ErrorOeder()
        {

        }
        public ErrorOeder(Guid userId) : base(userId)
        {

        }
        public Guid CustomerId { get; set; }
        public string ErroeId { get; set; }
        public string Msg { get; set; }
        public string Content { get; set; }
        /// <summary>
        /// Order From
        /// </summary>
        public string From { get; set; }
        /// <summary>
        /// Device Activity
        /// </summary>
    }
}
