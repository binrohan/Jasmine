using System;

namespace IqraCommerce.API.Params
{
    public class AppReviewParam
    {
        public AppReviewParam(){ }

        public AppReviewParam(Guid? customerId = null,
                              int take = 10,
                              int index = 1)
        {
            CustomerId = customerId;
            Take = take;
            Index = index;
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

        private int _index;
        public int Index 
        { 
            get { return _index; }
            private set {_index = value == 0 ? 1 : value; }
        }

        private int _skip;
        public int Skip
        {
            get { return _index * _take - _take; }
            private set { _skip = value; }
        }

        public Guid? CustomerId { get; set; }
    }
}