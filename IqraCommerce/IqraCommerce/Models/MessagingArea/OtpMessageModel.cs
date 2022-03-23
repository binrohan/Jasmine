﻿using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Models.MessagingArea
{
    [Table("OtpMessage")]
    [Alias("ntc")]
    public partial class OtpMessageModel : AppBaseModel
    {
        /// <summary>
        /// Phone Number
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// OTP Code sent to mobile
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Message Sent to mobile
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Website|Android
        /// </summary>
        public string AppType { get; set; }
        /// <summary>
        /// Login|PasswordReset
        /// </summary>
        public string From { get; set; }
        /// <summary>
        /// Time At Verified.
        /// </summary>
        public DateTime VerifiedAt { get; set; } = DateTime.MaxValue;
        /// <summary>
        /// Waiting|Verified|Expaired
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// How many times to try.
        /// </summary>
        public int CheckedCount { get; set; }
        /// <summary>
        /// Location
        /// </summary>
        public double Lan { get; set; }
        /// <summary>
        /// Location
        /// </summary>
        public double Lat { get; set; }
        /// <summary>
        /// MessageId From SMS Api
        /// </summary>
        /// 
        public string MessageId { get; set; }
        /// <summary>
        /// Device Activity
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Not In Database
        /// </summary>

    }
}