using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Models.CommonArea
{

    public class EntityDeleteModel
    {
        public Guid Id { get; set; }
        public Guid ActivityId { get; set; }
    }
    public class EntityDateModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid ActivityId { get; set; }
    }
    public class EntityDescriptionModel
    {
        public Guid Id { get; set; }
        public string Remarks { get; set; }
        public Guid ActivityId { get; set; }
    }
}
