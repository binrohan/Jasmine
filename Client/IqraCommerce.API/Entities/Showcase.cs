namespace IqraCommerce.API.Entities
{
    public class Showcase : BaseEntity
    {
        public string ImageURL { get; set; }
        public double Rank { get; set; }
        public bool IsVisible { get; set; }
    }
}