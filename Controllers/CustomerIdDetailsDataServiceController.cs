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
    public class CustomerIdDetailsDataServiceController : ControllerBase
    {
        private readonly ICustomerIdDetailsDataService _CustomerIdDetailsDataService;
        private readonly ILogger<CustomerIdDetailsDataServiceController> _logger;
        public CustomerIdDetailsDataServiceController(ICustomerIdDetailsDataService customerIdDetailsDataServic, ILogger<CustomerIdDetailsDataServiceController> logger)
        {
            this._CustomerIdDetailsDataService = customerIdDetailsDataServic;
            _logger = logger;
        }
        [HttpGet("GetCustomerIdDetail/{Custcode}")]
        public async Task<ActionResult<IEnumerable<CustomerIdDetails>>> GetCustomerIdDetail(string Custcode)
        {

            try
            {
                var result = await _CustomerIdDetailsDataService.GetCustomerIdDetail(Custcode);

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
        [HttpGet("CustomerIdDetailsByID/{Custcode}")]
        public async Task<ActionResult<CustomerIdDetails>> CustomerIdDetailsByID([FromRoute] string Custcode)
        {
            try
            {
                var result = await _CustomerIdDetailsDataService.CustomerIdDetailsByID(Custcode);

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
     
        [HttpPost("SaveCustomerId")]
        public async Task<ActionResult<int>> SaveCustomerIdDetails(CustomerIdDetails customeriddetails)
        {
            try
            {
                if (customeriddetails == null)
                {
                    return BadRequest();
                }


                var result = await _CustomerIdDetailsDataService.SaveCustomerIdDetails(customeriddetails);
                return Ok(result);



            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error saving data");
            }
        }
        [HttpPost("EditCustomerId")]
        public async Task<ActionResult<int>> EditCustomerIdDetails(CustomerIdDetails customeriddetails)
        {
            try
            {
                if (customeriddetails == null)
                {
                    return BadRequest();
                }


                var result = await _CustomerIdDetailsDataService.EditCustomerIdDetails(customeriddetails);
                return Ok(result);



            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error saving data");
            }
        }
      
        [HttpGet("DeleteCustomerIdDetails/{Cutomercode}/{IdTypecode}")]
        public async Task<ActionResult<int>> DeleteCustomerIdDetails(string Cutomercode, string IdTypecode)
        {
            try
            {
                if (Cutomercode == null)
                {
                    return BadRequest();
                }


                var result = await _CustomerIdDetailsDataService.DeleteCustomerIdDetails(Cutomercode, IdTypecode);
                return Ok(result);



            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error saving data");
            }
        }

        [HttpGet("CustomerPrimaryIdDetailsByID/{Custcode}")]
        public async Task<ActionResult<CustomerIdDetails>> CustomerPrimaryIdDetailsByID([FromRoute] string Custcode)
        {
            try
            {
                var result = await _CustomerIdDetailsDataService.CustomerPrimaryIdDetailsByID(Custcode);

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
