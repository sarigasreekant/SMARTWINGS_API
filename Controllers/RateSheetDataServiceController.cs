using ForexDataService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMARTWINGS_API.Model.Rate;

namespace DHBForexAPI
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RateSheetDataServiceController : ControllerBase
    {
       
        private readonly IRateSheetDataService _rateSheetDataService;
        private readonly ILogger<RateSheetDataServiceController> _logger;
        public RateSheetDataServiceController(IRateSheetDataService rateSheetDataService, ILogger<RateSheetDataServiceController> logger)
        {
            this._rateSheetDataService = rateSheetDataService;
            _logger = logger;
        }
        [HttpGet("GetRateSheet/{Branchcode}")]
        public async Task<ActionResult<IEnumerable<RateSheet>>> GetRateSheet(string Branchcode)
        {

            try
            {
                var result = await _rateSheetDataService.GetRateSheet(Branchcode);

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
        [HttpGet("IsStockAvailable/{CurCode}/{sCashierCode}/{BranchCode}")]
        public async Task<ActionResult<decimal>> IsStockAvailable([FromRoute] string CurCode, string sCashierCode, string BranchCode)
        {
            try
            {
                var result = await _rateSheetDataService.IsStockAvailable(CurCode, sCashierCode, BranchCode);


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
        [HttpGet("GetRateSheetByCurCode/{CurCode}/{BranchCode}")]
        public async Task<ActionResult<RateSheet>> GetRateSheetByCurCode([FromRoute] string CurCode, string BranchCode)
        {
            try
            {
                var result = await _rateSheetDataService.GetRateSheetByCurCode(CurCode, BranchCode);

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
       
       
        
        [HttpGet("GetRateForForex/{CurCode}/{BranchCode}")]
        public async Task<ActionResult<RateSheet>> GetRateForForex([FromRoute] string CurCode, string BranchCode)
        {
            try
            {
                var result = await _rateSheetDataService.GetRateForForex(CurCode, BranchCode);

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
