﻿using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.Entities
{
    public class CustomerAddress : BaseEntity
    {
       
        public Guid CustomerId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public int UpazilaId { get; set; }
        public int UnionId { get; set; }
        public AddressType TypeOfAddress { get; set; }
        public bool IsPrimary { get; set; }
    }
}