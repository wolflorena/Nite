using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Nite.API.Data.Models;
using Nite.API.Services;

namespace Nite.API.Controllers
{

    [ApiController]
    [Route("api/shows")]
    public class TVShowsController : ControllerBase
    {
        private readonly ILogger<TVShowsController> _logger;
        private readonly ITVShowsServiceModel _service;


        public TVShowsController(ILogger<TVShowsController> logger, ITVShowsServiceModel service)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public IActionResult GetTVShows()
        {
            try
            {
                var result = _service.GetTVShowsService();

                return Ok(result);
            }
            catch
            {
                _logger.LogCritical($"Exception while getting TV shows!");
                return StatusCode(500, "A problem happend while handling your request!");
            }
        }


        [HttpGet("{id}", Name = "GetTVShow")]
        public IActionResult GetTVShow(int id)
        {
            try
            {
                var result = _service.GetTVShowService(id);

                if (result == null)
                {
                    _logger.LogInformation($"TV show with id {id} wasn't found!");
                    return NotFound();
                }

                return Ok(result);
            }
            catch
            {
                _logger.LogCritical($"Exception while getting TV show with id {id}!");
                return StatusCode(500, "A problem happend while handling your request!");
            }
        }

        [HttpPost]
        public IActionResult CreateTVShow([FromBody] TVShowCreationDTO show)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = _service.AddTVShowService(show);

                return CreatedAtRoute(
                    "GetTVShow",
                    new { id = result },
                    result
                    );
            }
            catch
            {
                _logger.LogCritical($"Exception while creating a TV show!");
                return StatusCode(500, "A problem happend while handling your request!");
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateTVShow(int id, [FromBody] TVShowUpdateDTO show)
        {
            try
            {
                if (!_service.TVShowExistService(id))
                {
                    _logger.LogInformation($"TV show with id {id} wasn't found!");
                    return NotFound();
                }

                _service.UpdateWithPutTVShow(id, show);
                _service.SaveService();

                return NoContent();
            }
            catch
            {
                _logger.LogCritical($"Exception while updating TV show with id {id}");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }



        [HttpPatch("{id}")]
        public IActionResult PartialUpdateTVShow(int id, [FromBody] JsonPatchDocument<TVShowUpdateDTO> patchDoc)
        {
            try
            {
                if (!_service.TVShowExistService(id))
                {
                    _logger.LogInformation($"TV show with id {id} wasn't found!");
                    return NotFound();
                }

                var TVShowToPatch = _service.UpdateWithPatchTVShow(id);

                patchDoc.ApplyTo(TVShowToPatch, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (!TryValidateModel(TVShowToPatch))
                {
                    return BadRequest(ModelState);
                }


                _service.UpdateTVShowFinishService(id, TVShowToPatch);
                _service.SaveService();

                return NoContent();
            }
            catch
            {
                _logger.LogCritical($"Exception while updating the TV show with id {id}!");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }




        [HttpDelete("{id}")]
        public IActionResult DeleteTVShow(int id)
        {
            try
            {
                if (!_service.TVShowExistService(id))
                {
                    _logger.LogInformation($"TV show with id {id} wasn't found!");
                    return NotFound();
                }

                _service.DeleteTVShowService(id);

                return NoContent();
            }
            catch
            {
                _logger.LogCritical($"Exception while deleting the TV show with id {id}!");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }
    }
}
