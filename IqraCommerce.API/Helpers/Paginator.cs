using System.Collections.Generic;

namespace IqraCommerce.API.Helpers
{
    public class Pagination<T> where T : class
    {
        public Pagination(int index, int take, int count, IReadOnlyList<T> data)
        {
            Index = index;
            Take = take;
            Count = count;
            Data = data;
        }

        public int Index { get; set; }
        public int Take { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}