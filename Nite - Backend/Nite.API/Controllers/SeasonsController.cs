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
    }
}