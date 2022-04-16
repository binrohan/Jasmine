using System;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.Params
{
    public class OrderParam
    {

        public OrderParam()
        {

        }
        public OrderParam(Guid customerId, int index = 1, string search = null, bool isDecending = true)
        {
            IsDecending = isDecending;
            Search = search;
            Index = index;
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
        
        private string _search;
        public string Search
        {
            get { return _search; }
            set { _search = value?.ToLower(); }
        }


        public int Index { get; set; } = 1;

        public OrderBy OrderBy { get; set; }
        public bool IsDecending { get; set; }

        public Guid CustomerId { get; set; } = Guid.Empty;
    }
}