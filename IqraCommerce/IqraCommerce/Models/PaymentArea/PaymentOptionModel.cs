namespace EBonik.Data.Models.PaymentArea
{
    public class PaymentOptionModel
    {
        public PaymentOptionModel()
        {
            ExamFee = 50;
            HalfCourse = 1750;
            FullCourse = 3500;
        }

        public long UserId { get; set; }
        public long ExamId { get; set; }
        public double ExamFee { get; set; }
        public double HalfCourse { get; set; }
        public double FullCourse { get; set; }
        public double Balance { get; set; }
        public double Spent { get; set; }
        public int Version { get; set; }
    }
}
