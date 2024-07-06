using ForexDataService;
using ForexModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DHBForexAPI
{
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DropDwnListDataController : ControllerBase
    {
        private readonly IDropDwnListDataService _dropDwnListDataService;
        private readonly ILogger<DropDwnListDataController> _logger;
        public DropDwnListDataController(IDropDwnListDataService dropDwnListDataService, ILogger<DropDwnListDataController> logger)
        {
            this._dropDwnListDataService = dropDwnListDataService;
            _logger = logger;
        }
        [HttpGet("GetDropDwnListIdTextBranch/{dropType}/{Id}/{Parameter}")]
        public async Task<ActionResult<IEnumerable<DropDwnList>>> GetDropDwnListIdText(string dropType, string Id = "", string Parameter = "")
        {

            try
            {
                var result = await _dropDwnListDataService.GetDropDwnListIdText(dropType, Id, Parameter);

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
