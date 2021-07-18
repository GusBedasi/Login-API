using System;

namespace Application.DTO.Response
{
    public class CreateUserResponse
    {
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Active { get; set; }
        public string Roles { get; set; }
    }
}