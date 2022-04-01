namespace IqraCommerce.API.Helpers
{
    public class Param
    {
        private int maxTake = 50;
        private int take = 10;
        public int Take
        {
            get { return take; }
            set 
            { 
                take = value > maxTake ? maxTake : value; 
            }
        }
        
        public int Index { get; set; } = 0;
        public int Length { get; set; }
    }
}