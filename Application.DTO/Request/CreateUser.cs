using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Application.DTO.Contracts;
using Domain.Aggregates.UserAgg.Enumerators;
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
        public string Birthday { get; set; }

        [Required, StringLength(20)]
        [JsonProperty("username"), DisplayName("username")]
        public string Username { get; set; }
        
        [Required, StringLength(20)]
        [JsonProperty("password"), DisplayName("password")]
        public string Password { get; set; }

        [Required]
        [JsonProperty("role"), DisplayName("role")]
        public string Role { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (RolesTypes.GetValues().ToList().Contains(Role) == false)
            {
                results.Add(new ValidationResult(string.Join("The allowed roles are:,", RolesTypes.GetValues())));
            }
            
            return results;
        }
    }
}