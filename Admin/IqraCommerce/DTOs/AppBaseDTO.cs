using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.DTOs
{
    public class AppBaseDTO
    {
        public AppBaseDTO()
        {

        }
        public AppBaseDTO(Guid UserId)
        {
            CreatedBy = UpdatedBy = UserId;
        }
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public Guid UpdatedBy { get; set; }
        //public string Remarks { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string Remarks { get; set; }
        public Guid ActivityId { get; set; } = Guid.Empty;
    }
}
