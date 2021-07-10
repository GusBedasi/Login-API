using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Application.DTO.Contracts;

namespace Application.DTO.Request
{
    public class UpdateUser : IUpdateUser, IValidatableObject
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public DateTime Birthday { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            var age = int.Parse(Birthday.ToString("dd/MM/yyyy"));
            var currentYear = int.Parse(DateTime.UtcNow.ToString("dd/Mm/yyyy"));
            if ((age - currentYear) / 10000 < 18)
            {
                results.Add(new ValidationResult("Forbidden to -18"));
            }

            return results;
        }
    }
}