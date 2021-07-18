using System;

namespace Application.DTO.Contracts
{
    public interface IUpdateUser
    {
        string Username { get; set; }
        string Password { get; set; }
        bool Active { get; set; }
        DateTime Birthday { get; set; }
        string Role { get; set; }
    }
}