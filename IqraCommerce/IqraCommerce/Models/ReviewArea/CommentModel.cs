using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Models.ReviewArea
{
    [Table("Comment")]
    [Alias("cmnt")]
    public partial class CommentModel : AppBaseModel
    {
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerContent { get; set; }

        /// <summary>
        /// Device Activity
        /// </summary>


        /// <summary>
        /// Currently Not Use
        /// </summary>
        //public string CustomerProductImage { get; set; }

        //public string CommentStatus { get; set; }

        //public string CommentType { get; set; }

    }
}
