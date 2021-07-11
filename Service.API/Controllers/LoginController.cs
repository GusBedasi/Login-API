using Application.DTO.Contracts;
using Application.DTO.Request;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.API.Mappers;

namespace Service.API.Controllers
{
    [Route("login")]
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

        [Route(""), HttpPost]
        public IActionResult CreateUser([FromBody] CreateUser request)
        {
            var result = _loginService.CreateUser(request);

            var response = UserMapper.MapDTOToCreateRecipientResponse(result);

            return Ok(response);
        }
        
    }
}