using System;

namespace IqraCommerce.API.DTOs
{
    public interface IBaseDto
    {
        Guid Id { get; set; }
        DateTime CreatedAt { get; set; }
        Guid CreatedBy { get; set; }
        DateTime UpdatedAt { get; set; }
        Guid UpdatedBy { get; set; }
    }
}