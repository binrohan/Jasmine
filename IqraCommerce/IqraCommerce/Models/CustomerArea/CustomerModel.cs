using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Models.CustomerArea
{
    [Table("Customer")]
    [Alias("cstmr")]
    public class CustomerModel : DropDownBaseModel
    {
        [Required]
        public string Phone { get; set; }
        /// <summary>
        /// Optional
        /// </summary>
        public string Email { get; set; }
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

    public class UpdateCustomerInfoModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// ActivityId
        /// </summary>
    }
    public class UpdateCustomerPasswordModel
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Password { get; set; }
    }
    public class CustomerCreateModel : DropDownBaseModel
    {
        [Required]
        public string Phone { get; set; }
        /// <summary>
        /// Optional
        /// </summary>
        public string Email { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Password { get; set; }
    }
}
