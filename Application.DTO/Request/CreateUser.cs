using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Application.DTO.Contracts;
using Newtonsoft.Json;

namespace Application.DTO.Request
{
    public class CreateUser : ICreateUser, IValidatableObject
    {
        [Required, StringLength(40)]
        [JsonProperty("name"), DisplayName("name")]
        public string Name { get; set; }
        
        [Required]
        [JsonProperty("birthday"), DisplayName("birthday")]
        public DateTime Birthday { get; set; }
        
        [Required, StringLength(20)]
        [JsonProperty("username"), DisplayName("username")]
        public string Username { get; set; }
        
        [Required, StringLength(20)]
        [JsonProperty("password"), DisplayName("password")]
        public string Password { get; set; }
        
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