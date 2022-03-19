using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.CustomerArea
{
    [Table("Customer")]
    [Alias("cstmr")]
    public class Customer : DropDownBaseEntity
    {

        [Required]
        public string Phone { get; set; }
        /// <summary>
        /// Optional
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Cashback
        /// Cashback can not be returned.
        /// </summary>
        public double Cashback { get; set; }
        /// <summary>
        /// OrderAmountPending
        /// When Paid Order Amount will be reduce
        /// </summary>
        public double OrderAmountPending { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Password { get; set; }
        /// <summary>
        /// Image Path
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// OtpMessage.Id
        /// </summary>
        public Guid OTPId { get; set; }
        /// <summary>
        /// ActivityId
        /// </summary>
    }
}
