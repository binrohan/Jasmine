using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class Career
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string Remarks { get; set; }
        public Guid ActivityId { get; set; }
        public string Name { get; set; }
        public string Vacancy { get; set; }
        public string JobContext { get; set; }
        public string JobResponsibility { get; set; }
        public string EmploymentStatus { get; set; }
        public string Workplace { get; set; }
        public string EducationalRequirement { get; set; }
        public string AdditionalRequirement { get; set; }
        public string JobLocation { get; set; }
        public string Salary { get; set; }
        public string OtherBenifites { get; set; }
        public string ApplicantCv { get; set; }
        public int FileCount { get; set; }
    }
}
