using System;
using Application.DTO.Contracts;
using Domain.Contracts;
using Domain.Seedwork;

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

        public User(ICreateUser user, string cryptedPassword)
        {
            Name = user.Name;
            Username = user.Username;
            CryptedPassword = cryptedPassword;
            Birthday = Convert.ToDateTime(user.Birthday).Date;
            ExternalId = Code.Create("user_");
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Active = true;
            Roles = user.Role;
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
        public string Roles { get; set; }
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