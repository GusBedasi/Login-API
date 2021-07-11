using System;
using Domain.Contracts;

namespace Domain.Aggregates.UserAgg.Entities
{
    public class User : IEntity
    {
        public User()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Active = true;
        }

        public int Id { get; set; }
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Username { get; set; }
        public string CryptedPassword { get; set; }
        public bool Active { get; private set; }

        public void Enable(bool enable)
        {
            Active = enable;
        }
        
        public bool IsActive()
        {
            return Active;
        }
    }
}