using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        
        
    }
}