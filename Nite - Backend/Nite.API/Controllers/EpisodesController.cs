using Microsoft.AspNetCore.Mvc;
using Nite.API.Data.Models;
using Nite.API.Services;

namespace Nite.API.Controllers
{
    public class EpisodesController : ControllerBase
    {
        private readonly ILogger<EpisodesController> _logger;
        private readonly IEpisodesServiceModel _service;

        public EpisodesController(ILogger<EpisodesController> logger, IEpisodesServiceModel service)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }


        [HttpGet("api/episodes")]
        public IActionResult GetEpisodes()
        {
            try
            {
                var result = _service.GetAllEpisodesService();

                return Ok(result);
            }
            catch
            {
                _logger.LogCritical($"Exception while getting all episodes.");
                return StatusCode(500, "A problem happend while handling your request.");
            }

        }





        [HttpGet("api/shows/{showId}/seasons/{seasonId}/episodes")]
        public IActionResult GetEpisodes(int showId, int seasonId)
        {
            try
            {
                if (!_service.TVShowExistService(showId))
                {
                    _logger.LogInformation($"TV show with id {showId} wasn't found!");
                    return NotFound();
                }

                if (!_service.SeasonExistService(showId, seasonId))
                {
                    _logger.LogInformation($"Season with id {seasonId} wasn't found!");
                    return NotFound();
                }

                var result = _service.GetEpisodesService(showId, seasonId);

                return Ok(result);
            }
            catch
            {
                _logger.LogCritical($"Exception while getting episodes for season with id {seasonId} and TV show with id {showId}");
                return StatusCode(500, "A problem happend while handling your request.");
            }

        }


        [HttpGet("api/shows/{showId}/seasons/{seasonId}/episodes/{id}", Name = "GetEpisode")]
        public IActionResult GetEpisode(int showId, int seasonId, int id)
        {
            try
            {
                if (!_service.TVShowExistService(showId))
                {
                    _logger.LogInformation($"TV show with id {showId} wasn't found!");
                    return NotFound();
                }

                if (!_service.SeasonExistService(showId, seasonId))
                {
                    _logger.LogInformation($"Season with id {seasonId} wasn't found!");
                    return NotFound();
                }


                var result = _service.GetEpisodeService(showId, seasonId, id);

                if (result == null)
                {
                    _logger.LogInformation($"Episode with id {id} wasn't found!");
                    return NotFound();
                }

                return Ok(result);
            }
            catch
            {
                _logger.LogCritical($"Exception while getting episode with id {id} from the season with id {seasonId} and TV show with id {showId}");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }

        [HttpDelete("api/shows/{showId}/seasons/{seasonId}/episodes/{id}")]
        public IActionResult DeleteEpisode(int showId, int seasonId, int id)
        {
            try
            { 
                if (!_service.TVShowExistService(showId))
                {
                    _logger.LogInformation($"TV show with id {showId} wasn't found!");
                    return NotFound();
                }

                if (!_service.SeasonExistService(showId, seasonId))
                {
                    _logger.LogInformation($"Season with id {seasonId} wasn't found!");
                    return NotFound();
                }

                var result = _service.GetEpisodeService(showId, seasonId, id);

                if (result == null)
                {
                    _logger.LogInformation($"Episode with id {id} wasn't found!");
                    return NotFound();
                }

                _service.DeleteEpisodeService(showId, seasonId, id);

                return NoContent();
            }
            catch
            {
                _logger.LogCritical($"Exception while deleting episode with id {id} from the season with id {seasonId} and TV show with id {showId}");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }


        [HttpPost("api/shows/{showId}/seasons/{seasonId}/episodes")]
        public IActionResult CreateEpisode(int showId, int seasonId, [FromBody] EpisodeCreationDTO episode)
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

                if (!_service.SeasonExistService(showId, seasonId))
                {
                    _logger.LogInformation($"Season with id {seasonId} wasn't found!");
                    return NotFound();
                }

                var result = _service.AddEpisodeService(showId, seasonId, episode);

                return CreatedAtRoute(
                    "GetEpisode",
                    new { showId, seasonId, id = result.Id },
                    result
                    );
            }
            catch
            {
                _logger.LogCritical($"Exception while creating an episode for the season with id {seasonId} and TV show with id {showId}");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }


        [HttpPut("api/shows/{showId}/seasons/{seasonId}/episodes/{id}")]
        public IActionResult UpdateEpisode(int showId, int seasonId, int id, [FromBody] EpisodeUpdateDTO episode)
        {
            try
            {
                if (!_service.TVShowExistService(showId))
                {
                    _logger.LogInformation($"TV show with id {showId} wasn't found!");
                    return NotFound();
                }

                if (!_service.SeasonExistService(showId, seasonId))
                {
                    _logger.LogInformation($"Season with id {seasonId} wasn't found!");
                    return NotFound();
                }

                var episodeEntity = _service.GetEpisodeService(showId, seasonId, id);

                if (episodeEntity == null)
                {
                    _logger.LogInformation($"Episode with id {id} wasn't found!");
                    return NotFound();
                }

                _service.UpdateWithPutEpisode(showId, seasonId, id, episode);
                _service.SaveService();

                return NoContent();
            }
            catch
            {
                _logger.LogCritical($"Exception while updating episode with id {id} from the season with id {seasonId} and TV show with id {showId}");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }
    }
}
