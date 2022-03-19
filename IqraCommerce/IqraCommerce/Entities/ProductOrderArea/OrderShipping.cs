using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Entities.ProductOrderArea
{
    [Table("OrderShipping")]
    [Alias("odrspng")]
    public partial class OrderShipping : DropDownBaseEntity
    {
        public OrderShipping()
        {

        }
        public OrderShipping(Guid userId) : base(userId)
        {

        }
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// Home|Office|Home Town
        /// </summary>
        public string Type { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public int UpazilaId { get; set; }
        public int UnionId { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
