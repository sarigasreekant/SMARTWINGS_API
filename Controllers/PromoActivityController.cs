using DataAccess;
using ForexDataService;
using ForexModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DHBForexAPI
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PromoActivityController : ControllerBase
    {
        private readonly IPromoActivityDataService _promoActivityDataService;
        private readonly ILogger<PromoActivityController> _logger;
        public PromoActivityController(IPromoActivityDataService promoActivityDataService, ILogger<PromoActivityController> logger)
        {
            this._promoActivityDataService = promoActivityDataService;
            _logger = logger;
        }

        

        [HttpGet("GetPromoActivity")]
        public async Task<ActionResult<IEnumerable<PromotionalActivity>>> GetPromoActivity()
        {

            try
            {
                var result = await _promoActivityDataService.GetPromoActivity();

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result.ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }

        }
        [HttpGet("GetPromoActivityByID/{PromoCode}")]
        public async Task<ActionResult<PromotionalActivity>> GetPromoActivityByID([FromRoute] string PromoCode)
        {
            try
            {
                var result = await _promoActivityDataService.GetPromoActivityByID(PromoCode);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }
        }
        [HttpPost("SavePromoActivity")]
        public async Task<ActionResult<int>> SavePromoActivity(PromotionalActivity promoActivity)
        {
            try
            {
                if (promoActivity == null)
                {
                    return BadRequest();
                }


                var result = await _promoActivityDataService.SavePromoActivity(promoActivity);
                return Ok(result);



            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error saving data");
            }
        }
        [HttpPost("EditPromoActivity")]
        public async Task<ActionResult<int>> EditPromoActivity(PromotionalActivity promoActivity)
        {
            try
            {
                if (promoActivity == null)
                {
                    return BadRequest();
                }


                var result = await _promoActivityDataService.EditPromoActivity(promoActivity);
                return Ok(result);



            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error saving data");
            }
        }
    }
}
