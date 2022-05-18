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
                            int index = 1,
                            bool isDecending = false)
        {
            Take = take;
            Index = index;
            OrderBy = orderBy;
            IsDecending = isDecending;

        }
        private int maxTake = 50;
        private int _take = 10;
        public int Take
        {
            get { return _take == 0 ? 1 : _take; }
            set
            {
                _take = value > maxTake ? maxTake : value;
            }
        }
        public int Index { get; }
        private int _skip;
        public int Skip
        {
            get { return Index * _take - _take; }
            private set { _skip = value; }
        }
        public OrderBy OrderBy { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsVisible { get; set; } = true;
        public bool IsDecending { get; set; }
    }
}