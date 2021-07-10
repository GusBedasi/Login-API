using System.ComponentModel.DataAnnotations;
using Application.DTO.Contracts;

namespace Application.DTO.Request
{
    public class Login : ILogin
    {
        [Required, StringLength(20)]
        public string Username { get; set; }
        
        [Required, StringLength(20)]
        public string Password { get; set; }
    }
}