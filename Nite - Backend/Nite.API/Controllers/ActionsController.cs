using Microsoft.AspNetCore.Mvc;
using Nite.API.Data.Models;
using Nite.API.Migrations;
using Nite.API.Repository.Entities;
using Nite.API.Services;

namespace Nite.API.Controllers
{
    public class ActionsController : ControllerBase
    {
        private readonly ILogger<ActionsController> _logger;
        private readonly IActionsServiceModel _service;

        public ActionsController(ILogger<ActionsController> logger, IActionsServiceModel service)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }


        [HttpGet("api/favorites/{userId}", Name = "GetFavorites")]
        public IActionResult GetFavorites(int userId)
        {
            try
            {
                var result = _service.GetAllFavoritesService(userId);

                return Ok(result);
            }
            catch
            {
                _logger.LogCritical($"Exception while getting all favorites.");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }

        [HttpGet("api/added/{userId}", Name = "GetAddedShows")]
        public IActionResult GetAddedShows(int userId)
        {
            try
            {
                var result = _service.GetAllAddedShowsService(userId);

                return Ok(result);
            }
            catch
            {
                _logger.LogCritical($"Exception while getting all added shows.");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }

        [HttpGet("api/watched/{userId}", Name = "GetWatchedEpisodes")]
        public IActionResult GetWatchedEpisodes(int userId)
        {
            try
            {
                var result = _service.GetAllWatchedEpisodesService(userId);

                return Ok(result);
            }
            catch
            {
                _logger.LogCritical($"Exception while getting all watched episodes.");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }


        [HttpPost("api/favorites/{userId}/{showId}")]
        public IActionResult AddFavorite(int userId, int showId, [FromBody] FavoritesCreationDTO favorite)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (!_service.UserExistService(userId))
                {
                    _logger.LogInformation($"User with id {userId} wasn't found!");
                    return NotFound();
                }

                if (!_service.ShowExistService(showId))
                {
                    _logger.LogInformation($" TV Show with id {showId} wasn't found!");
                    return NotFound();
                }

                var result = _service.AddFavoriteService(favorite);

                return CreatedAtRoute(
                    "GetFavorites",
                    new { userId, showId, id = result.Id },
                    result
                    );
            }
            catch
            {
                _logger.LogCritical($"Exception while adding a show as a favorite.");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }


        [HttpPost("api/added/{userId}/{showId}")]
        public IActionResult AddAddedShow(int userId, int showId, [FromBody] AddCreationDTO added)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (!_service.UserExistService(userId))
                {
                    _logger.LogInformation($"User with id {userId} wasn't found!");
                    return NotFound();
                }

                if (!_service.ShowExistService(showId))
                {
                    _logger.LogInformation($" TV Show with id {showId} wasn't found!");
                    return NotFound();
                }

                var result = _service.AddAddedShowService(added);

                return CreatedAtRoute(
                "GetAddedShows",
                    new {userId, showId, id = result.Id },
                    result
                    );
            }
            catch
            {
                _logger.LogCritical($"Exception while adding a show in add list.");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }


        [HttpPost("api/watched/{userId}/{showId}/{seasonId}/{episodeId}")]
        public IActionResult AddWatchedEpisodeShow(int userId, int showId, int seasonId, int episodeId, [FromBody] WatchCreationDTO watched)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (!_service.UserExistService(userId))
                {
                    _logger.LogInformation($"User with id {userId} wasn't found!");
                    return NotFound();
                }

                if (!_service.ShowExistService(showId))
                {
                    _logger.LogInformation($"TV Show with id {showId} wasn't found!");
                    return NotFound();
                }

                if (!_service.SeasonExistService(seasonId))
                {
                    _logger.LogInformation($"Season with id {seasonId} wasn't found!");
                    return NotFound();
                }

                if (!_service.EpisodeExistService(episodeId))
                {
                    _logger.LogInformation($"Episode with id {episodeId} wasn't found!");
                    return NotFound();
                }

                var result = _service.AddWatchedEpisodeService(watched, userId, showId);

                return CreatedAtRoute(
                "GetWatchedEpisodes",
                    new { userId, showId, seasonId, episodeId, id = result.Id },
                    result
                    );
            }
            catch
            {
                _logger.LogCritical($"Exception while adding a show in watching list.");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }

        [HttpDelete("api/favorites/{userId}/{showId}")]
        public IActionResult DeleteFavorite(int userId, int showId)
        {
            try
            {
                if (!_service.UserExistService(userId))
                {
                    _logger.LogInformation($"User with id {userId} wasn't found!");
                    return NotFound();
                }

                if (!_service.ShowExistService(showId))
                {
                    _logger.LogInformation($" TV Show with id {showId} wasn't found!");
                    return NotFound();
                }

                var result = _service.GetFavoriteService(userId, showId);

                if (result == null)
                {
                    _logger.LogInformation($"Favorite TV show wasn't found!");
                    return NotFound();
                }

                _service.DeleteFavoriteService(userId, showId);

                return NoContent();
            }
            catch
            {
                _logger.LogCritical($"Exception while deleting favorite show.");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }

        [HttpDelete("api/added/{userId}/{showId}")]
        public IActionResult DeleteAddedShow(int userId, int showId)
        {
            try
            {
                if (!_service.UserExistService(userId))
                {
                    _logger.LogInformation($"User with id {userId} wasn't found!");
                    return NotFound();
                }

                if (!_service.ShowExistService(showId))
                {
                    _logger.LogInformation($" TV Show with id {showId} wasn't found!");
                    return NotFound();
                }

                var result = _service.GetAddedShowService(userId, showId);

                if (result == null)
                {
                    _logger.LogInformation($"Added TV show wasn't found!");
                    return NotFound();
                }

                _service.DeleteAddedShowService(userId, showId);

                return NoContent();
            }
            catch
            {
                _logger.LogCritical($"Exception while deleting added show.");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }


        [HttpDelete("api/watched/{userId}/{showId}/{seasonId}/{episodeId}")]
        public IActionResult DeleteWatchedEpisode(int userId, int showId, int seasonId, int episodeId)
        {
            try
            {
                if (!_service.UserExistService(userId))
                {
                    _logger.LogInformation($"User with id {userId} wasn't found!");
                    return NotFound();
                }

                if (!_service.ShowExistService(showId))
                {
                    _logger.LogInformation($" TV Show with id {showId} wasn't found!");
                    return NotFound();
                }

                if (!_service.SeasonExistService(seasonId))
                {
                    _logger.LogInformation($"Season with id {seasonId} wasn't found!");
                    return NotFound();
                }

                if (!_service.EpisodeExistService(episodeId))
                {
                    _logger.LogInformation($"Episode with id {episodeId} wasn't found!");
                    return NotFound();
                }

                var result = _service.GetWatchedEpisodeService(userId, showId, seasonId, episodeId);

                if (result == null)
                {
                    _logger.LogInformation($"Watched episode wasn't found!");
                    return NotFound();
                }

                _service.DeleteWatchedEpisodeService(userId, showId, seasonId, episodeId);

                return NoContent();
            }
            catch
            {
                _logger.LogCritical($"Exception while deleting watched episode.");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }
    }
}
