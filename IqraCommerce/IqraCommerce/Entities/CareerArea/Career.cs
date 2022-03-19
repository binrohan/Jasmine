using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.CareerArea
{
    [Table("Career")]
    [Alias("crer")]
    public class Career : DropDownBaseEntity
    {
        public string Vacancy { get; set; }
        public string JobContext { get; set; }
        public string JobResponsibility { get; set; }

        //Full-time || Part-time || Scheduled Time
        public string EmploymentStatus { get; set; }

        //Home || Office
        public string Workplace { get; set; }

        public string EducationalRequirement { get; set; }

        public string AdditionalRequirement { get; set; }

        public string JobLocation { get; set; }
        public string Salary { get; set; }

        //Yearly Bonus or Others
        public string OtherBenifites { get; set; }
        public string ApplicantCV { get; set; }

        public int FileCount { get; set; }


        /// <summary>
        /// Device Activity
        /// </summary>


    }
}
