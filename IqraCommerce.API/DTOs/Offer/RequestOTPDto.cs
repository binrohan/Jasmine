using IqraCommerce.API.Data;

namespace IqraCommerce.API.DTOs
{
    public class OfferReturnDto
    {
       public OfferType OfferType { get; set; }
        public string Headline { get; set; }
        public string Content { get; set; }
        public string ImageURL { get; set; }
    }
}