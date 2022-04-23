using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.DTOs
{
    public class DropDownBaseDTO : AppBaseDTO
    {
        public string Name { get; set; }

        public DropDownBaseDTO() : base()
        {

        }
        public DropDownBaseDTO(Guid UserId) : base(UserId)
        {

        }
    }
}
