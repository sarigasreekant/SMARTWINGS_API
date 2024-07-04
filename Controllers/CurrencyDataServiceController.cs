
using ForexDataService;
using ForexModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DHBForexAPI
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class CurrencyDataServiceController : ControllerBase
    {
        private readonly ICurrencyDataService _currencyDataService;
        private readonly ILogger<CurrencyDataServiceController> _logger;
        public CurrencyDataServiceController(ICurrencyDataService currencyDataService, ILogger<CurrencyDataServiceController> logger)
        {
            this._currencyDataService = currencyDataService;
            _logger = logger;
        }
        [HttpGet("GetCurrency")]
        public async Task<ActionResult<IEnumerable<Currency>>> GetCurrency()
        {

            try
            {
                var result = await _currencyDataService.GetCurrency();

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
      
    }
}
