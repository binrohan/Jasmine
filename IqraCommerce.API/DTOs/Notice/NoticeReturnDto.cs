using System;

namespace IqraCommerce.API.DTOs.Notice
{
    public class NoticeReturnDto
    {
        public string Content { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Rank { get; set; }
    }
}