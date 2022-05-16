using System;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.Params
{
    public class NotificationParam
    {
        public NotificationParam()
        {

        }
        public NotificationParam(Guid customerId,
                                int index = 1,
                                int take = 10)
        {
            Index = index;
            Take = take;
            CustomerId = customerId;
        }

        private int maxTake = 50;
        private int _take = 10;
        public int Take
        {
            get { return _take; }
            set
            {
                _take = value > maxTake ? maxTake : value;
            }
        }
        private int _skip;
        public int Skip
        {
            get { return Index * _take - _take; }
            set { _skip = value; }
        }
        public int Index { get; set; } = 1;
        public Guid CustomerId { get; set; } = Guid.Empty;
    }
}