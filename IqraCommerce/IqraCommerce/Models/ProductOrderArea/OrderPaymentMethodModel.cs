using IqraBase.Data;
using IqraBase.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Models.ProductOrderArea
{
    [Table("OrderPaymentMethod")]
    [Alias("odrpmntmth")]
    public partial class OrderPaymentMethodModel : DropDownBaseModel
    {
        /// <summary>
        /// Fixed|Percentage|Amount
        /// if a product have a regular price 200 and discount 30. 
        /// when DiscountType Fixed is used then discounted price will be 30.
        /// when DiscountType Percentage is used then discounted price will be 140.
        /// when DiscountType Amount is used then discounted price will be 170.
        /// </summary>
        public string DiscountType { get; set; }
        public double Discount { get; set; }
        public string Remarks { get; set; }
    }
}
