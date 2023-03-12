using Microsoft.AspNetCore.Mvc;
using Nite.API.Data.Models;
using Nite.API.Services;

namespace Nite.API.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IServiceModel _service;


        public LoginController(ILogger<LoginController> logger, IServiceModel service)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginDTO request)
        {
            try
            {
                var user = _service.LoginRequestService(request);

                if(user == null) 
                {
                    _logger.LogInformation($"User wasn't found!");
                    return NotFound();
                }

                return Ok(user);
            }
            catch
            {
                _logger.LogCritical($"Exception while logging!");
                return StatusCode(500, "A problem happend while handling your request!");
            }
        }
    }
}
