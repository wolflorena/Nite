using Microsoft.AspNetCore.Mvc;
using Nite.API.Data.Models;
using Nite.API.Services;

namespace Nite.API.Controllers
{
    public class SeasonsController : ControllerBase
    {
        private readonly ILogger<SeasonsController> _logger;
        private readonly ISeasonsServiceModel _service;

        public SeasonsController(ILogger<SeasonsController> logger, ISeasonsServiceModel service)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }




        [HttpGet("api/seasons")]
        public IActionResult GetSeasons()
        {
            try
            {
                var result = _service.GetAllSeasonsService();

                return Ok(result);
            }
            catch
            {
                _logger.LogCritical($"Exception while getting all seasons.");
                return StatusCode(500, "A problem happend while handling your request.");
            }

        }





        [HttpGet("api/shows/{showId}/seasons")]
        public IActionResult GetSeasons(int showId)
        {
            try
            {
                if (!_service.TVShowExistService(showId))
                {
                    _logger.LogInformation($"TV show with id {showId} wasn't found!");
                    return NotFound();
                }

                var result = _service.GetSeasonsService(showId);

                return Ok(result);
            }
            catch
            {
                _logger.LogCritical($"Exception while getting seasons for TV show with id {showId}");
                return StatusCode(500, "A problem happend while handling your request.");
            }

        }


        [HttpGet("api/shows/{showId}/seasons/{id}", Name = "GetSeason")]
        public IActionResult GetSeason(int showId, int id)
        {
            try
            {
                if (!_service.TVShowExistService(showId))
                {
                    _logger.LogInformation($"TV show with id {showId} wasn't found!");
                    return NotFound();
                }

                var result = _service.GetSeasonService(showId, id);

                if (result == null)
                {
                    _logger.LogInformation($"Season with id {id} wasn't found!");
                    return NotFound();
                }

                return Ok(result);
            }
            catch
            {
                _logger.LogCritical($"Exception while getting season with id {id} from the TV show with id {showId}");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }


        [HttpDelete("api/shows/{showId}/seasons/{id}")]
        public IActionResult DeleteSeason(int showId, int id)
        {
            try
            {

                if (!_service.TVShowExistService(showId))
                {
                    _logger.LogInformation($"TV show with id {showId} wasn't found!");
                    return NotFound();
                }

                var result = _service.GetSeasonService(showId, id);

                if (result == null)
                {
                    _logger.LogInformation($"Season with id {id} wasn't found!");
                    return NotFound();
                }

                _service.DeleteSeasonService(showId, id);

                return NoContent();
            }
            catch
            {
                _logger.LogCritical($"Exception while deleting season with id {id} from the TV show with id {showId}");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }


            [HttpPost("api/shows/{showId}/seasons")]
            public IActionResult CreateSeason(int showId, [FromBody] SeasonCreationDTO season)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest();
                    }

                    if (!_service.TVShowExistService(showId))
                    {
                        _logger.LogInformation($"TV show with id {showId} wasn't found!");
                        return NotFound();
                    }

                    var result = _service.AddSeasonService(showId, season);

                    return CreatedAtRoute(
                        "GetSeason",
                        new { showId, id = result.Id },
                        result
                        );
                }
                catch
                {
                    _logger.LogCritical($"Exception while creating a season for the TV show with id {showId}");
                    return StatusCode(500, "A problem happend while handling your request.");
                }
            }


            [HttpPut("api/shows/{showId}/seasons/{id}")]
            public IActionResult UpdateSeason(int showId, int id, [FromBody] SeasonUpdateDTO season)
            {
                try
                {

                    if (!_service.TVShowExistService(showId))
                    {
                        _logger.LogInformation($"TV show with id {showId} wasn't found!");
                        return NotFound();
                    }


                    var seasonEntity = _service.GetSeasonService(showId, id);

                    if (seasonEntity == null)
                    {
                        _logger.LogInformation($"Season with id {id} wasn't found!");
                        return NotFound();
                    }

                    _service.UpdateWithPutSeason(showId, id, season);
                    _service.SaveService();

                    return NoContent();
                }
                catch
                {
                    _logger.LogCritical($"Exception while updating season with id {id} for the TV show with id {showId}");
                    return StatusCode(500, "A problem happend while handling your request.");
                }
            }
    }
}
