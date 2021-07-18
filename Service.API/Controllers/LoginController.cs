using Application.DTO.Contracts;
using Application.DTO.Request;
using Application.Interfaces;
using Domain.Aggregates.UserAgg.Enumerators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.API.Mappers;

namespace Service.API.Controllers
{
    [Route("")]
    [ApiController]
    public class LoginController : Controller
    {
        private ILogger<LoginController> _logger;
        private ILoginService _loginService;
        
        public LoginController(ILogger<LoginController> logger, ILoginService loginService)
        {
            _logger = logger;
            _loginService = loginService;
        }
        
        
        [Route("/login"), HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] Login request)
        {
            var result = _loginService.Login(request);

            return Ok(result);
        }

        [Route(""), HttpPost]
        [AllowAnonymous]
        public IActionResult CreateUser([FromBody] CreateUser request)
        {
            var result = _loginService.CreateUser(request);

            var response = UserMapper.MapDTOToCreateUserResponse(result);

            return Ok(response);
        }

        [Route("/users/{username}"), HttpGet]
        [Authorize(Roles = RolesTypes.MANAGER)]
        public IActionResult GetUserByUsername(string username)
        {
            var response = _loginService.GetUserByUsername(username);

            return Ok(response);
        }
    }
}