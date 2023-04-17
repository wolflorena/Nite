using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Nite.API.Data.Models;
using Nite.API.Services;

namespace Nite.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IServiceModel _service;


        public UsersController(ILogger<UsersController> logger, IServiceModel service)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public IActionResult GetUsers() 
        {
            try
            {
                var result = _service.GetUsersService();

                return Ok(result);
            }
            catch
            {
                _logger.LogCritical($"Exception while getting users!");
                return StatusCode(500, "A problem happend while handling your request!");
            }
        }


        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetUser(int id) 
        { 
            try
            {
                var result = _service.GetUserService(id);

                if(result == null)
                {
                    _logger.LogInformation($"User with id {id} wasn't found!");
                    return NotFound();
                }

                return Ok(result);
            }
            catch
            {
                _logger.LogCritical($"Exception while getting user with id {id}!");
                return StatusCode(500, "A problem happend while handling your request!");
            }
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserCreationDTO user)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = _service.AddUserService(user);

                return CreatedAtRoute(
                    "GetUser",
                    new { id = result },
                    result
                    );
            }
            catch
            {
                _logger.LogCritical($"Exception while creating an user!");
                return StatusCode(500, "A problem happend while handling your request!");
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserUpdateDTO user)
        {
            try
            {
                if (!_service.UserExistService(id))
                {
                    _logger.LogInformation($"User with id {id} wasn't found!");
                    return NotFound();
                }

                _service.UpdateWithPutUser(id, user);
                _service.SaveService();

                return NoContent();
            }
            catch
            {
                _logger.LogCritical($"Exception while updating user with id {id}");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }


        [HttpPatch("{id}")]
        public IActionResult PartialUpdateUser(int id, [FromBody] JsonPatchDocument<UserUpdateDTO> patchDoc)
        {
            try
            {
                if (!_service.UserExistService(id))
                {
                    _logger.LogInformation($"User with id {id} wasn't found!");
                    return NotFound();
                }

                var UserToPatch = _service.UpdateWithPatchUser(id);

                patchDoc.ApplyTo(UserToPatch, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (!TryValidateModel(UserToPatch))
                {
                    return BadRequest(ModelState);
                }


                _service.UpdateUserFinishService(id, UserToPatch);
                _service.SaveService();

                return NoContent();
            }
            catch
            {
                _logger.LogCritical($"Exception while updating the user with id {id}!");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                if (!_service.UserExistService(id))
                {
                    _logger.LogInformation($"User with id {id} wasn't found!");
                    return NotFound();
                }

                _service.DeleteUserService(id);

                return NoContent();
            }
            catch
            {
                _logger.LogCritical($"Exception while deleting the user with id {id}!");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }
    }
}
