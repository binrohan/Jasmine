using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Models.ReviewArea
{
    [Table("Liker")]
    [Alias("lkr")]
    public class LikerModel : AppBaseModel
    {
        public Guid CustomerId { get; set; }
        public Guid CommentId { get; set; }
        /// <summary>
        /// Undo Like Or Unlike
        /// Unlike
        /// Like
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Not Using
        /// </summary>
        public string RelationType { get; set; }
    }
}
