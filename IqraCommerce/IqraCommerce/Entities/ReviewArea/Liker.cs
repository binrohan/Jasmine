using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Entities.ReviewArea
{
    [Table("Liker")]
    [Alias("lkr")]
    public class Liker : AppBaseEntity
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
