using System;

namespace Domain.Aggregates.UserAgg.Entities
{
    public class User
    {
        public User(bool active)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Active = active;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        private DateTime CreatedAt { get; }
        private DateTime? UpdatedAt { get; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CryptedPassword { get; set; }
        private bool Active { get; set; }

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