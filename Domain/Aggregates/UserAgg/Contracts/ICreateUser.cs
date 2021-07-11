using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Contracts
{
    public interface ICreateUser
    {
        string Name { get; set; }
        string Birthday { get; set; }
        string Username { get; set; }
        string Password { get; set; }
    }
}