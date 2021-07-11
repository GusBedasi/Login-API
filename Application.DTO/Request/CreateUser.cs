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
        public string Birthday { get; set; }

        [Required, StringLength(20)]
        [JsonProperty("username"), DisplayName("username")]
        public string Username { get; set; }
        
        [Required, StringLength(20)]
        [JsonProperty("password"), DisplayName("password")]
        public string Password { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            return results;
        }
    }
}