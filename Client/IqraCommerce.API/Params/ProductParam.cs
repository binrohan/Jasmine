using System;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.Params
{
    public class ProductParam
    {
        public ProductParam()
        {

        }
        public ProductParam(OrderBy orderBy = OrderBy.Rank,
                            int take = 10,
                            bool isDecending = false,
                            bool isDeleted = false,
                            bool isVisible = true)
        {
            Take = take;
            OrderBy = orderBy;
            IsDeleted = isDeleted;
            IsVisible = isVisible;
            IsDecending = isDecending;

        }
        public int Take { get; private set; } = 10;
        public OrderBy OrderBy { get; set; }
        public bool? IsHighlighted { get; set; } = null;
        public bool IsDeleted { get; set; }
        public bool IsVisible { get; set; } = true;
        public bool IsDecending { get; set; }
    }
}