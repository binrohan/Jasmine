using System;

namespace IqraCommerce.API.DTOs.Banner
{
    public class BannerReturnDto
    {
        public Guid Id { get; set; }
        public string ImageURL { get; set; }
        public string Link { get; set; }
        public double Rank { get; set; }
        public string Size { get; set; }
    }
}