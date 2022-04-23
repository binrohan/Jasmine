using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Helpers
{
    public static class OrderHistoryHelper
    {
        static public string GenerateHistoryMessage(OrderStatus prevStatus, OrderStatus nextStatus)
        {
            return $"Status changed from {status(prevStatus)} to {status(nextStatus)}";
        }

        private static string status(OrderStatus prevStatus)
        {
            string statusString;

            switch (prevStatus)
            {
                case OrderStatus.Pending:
                    statusString = "Pending";
                    break;
                case OrderStatus.Confirmed:
                    statusString = "Confirmed";
                    break;
                case OrderStatus.Processing:
                    statusString = "Processing";
                    break;
                case OrderStatus.Delivering:
                    statusString = "Delivering";
                    break;
                case OrderStatus.Delivered:
                    statusString = "Delivered";
                    break;
                case OrderStatus.CancelledByAdmin:
                    statusString = "Cancelled";
                    break;
                case OrderStatus.CanclledByCustomer:
                    statusString = "Cancelled";
                    break;
                case OrderStatus.Returned:
                    statusString = "Returned";
                    break;
                default:
                    statusString = "Unknown";
                    break;
            }

            return statusString;
        }
    }
}
