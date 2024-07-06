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
    public class RemittanceRateDtlsController : ControllerBase
    {
        private readonly IRemittanceRatedtlsDataService _remrateDataService;
        private readonly ILogger<RemittanceRateDtlsController> _logger;
        public RemittanceRateDtlsController(IRemittanceRatedtlsDataService remrateDataService, ILogger<RemittanceRateDtlsController> logger)
        {
            this._remrateDataService = remrateDataService;
            _logger = logger;
        }

        [HttpGet("GetRate/{ConCode}/{CurCode}/{BranchCode}/{ServCode}/{param1}/{param2}/{param3}")]
        public async Task<ActionResult<RemittanceRatedtls>> GetRate([FromRoute] string ConCode,string CurCode, string BranchCode, string ServCode,string param1,string param2,string param3)
        {
            try
            {
                var result = await _remrateDataService.GetRate(ConCode,CurCode,  BranchCode, ServCode,param1,param2,param3);

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
        [HttpPost("GetRateCommision")]
        public async Task<ActionResult<RemittanceRatedtls>> GetRateCommision(CommisionSearch commisionSearch)
        {

            try
            {
                var result = await _remrateDataService.GetRateCommision(commisionSearch);

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
    }
}
