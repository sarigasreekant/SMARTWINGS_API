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
    public class CustomerOtherDocumentController : ControllerBase
    {
        private readonly ICustomerOtherDocumentDataService _customerOtherDocumentDataService;
        private readonly ILogger<CustomerOtherDocumentController> _logger;
        public CustomerOtherDocumentController(ICustomerOtherDocumentDataService customerOtherDocumentDataService, ILogger<CustomerOtherDocumentController> logger)
        {
            this._customerOtherDocumentDataService = customerOtherDocumentDataService;
            _logger = logger;
        }
        [HttpGet("GetCustomerOtherDocument/{Custcode}")]
        public async Task<ActionResult<IEnumerable<CustomerOtherDocument>>> GetCustomerOtherDocument(string Custcode)
        {

            try
            {
                var result = await _customerOtherDocumentDataService.GetCustomerOtherDocument(Custcode);

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
        [HttpGet("GetCustomerOtherDocumentID/{Id}")]
        public async Task<ActionResult<CustomerOtherDocument>> GetCustomerOtherDocumentID([FromRoute] int Id)
        {
            try
            {
                var result = await _customerOtherDocumentDataService.GetCustomerOtherDocumentID(Id);

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
        [HttpPost("SaveCustomerOtherDocument")]
        public async Task<ActionResult<int>> SaveCustomerOtherDocument(CustomerOtherDocument customerotherdocument)
        {
            try
            {
                if (customerotherdocument == null)
                {
                    return BadRequest();
                }


                var result = await _customerOtherDocumentDataService.SaveCustomerOtherDocument(customerotherdocument);
                return Ok(result);



            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error saving data");
            }
        }
        [HttpPost("EditCustomerOtherDocument")]
        public async Task<ActionResult<int>> EditCustomerOtherDocument(CustomerOtherDocument customerotherdocument)
        {
            try
            {
                if (customerotherdocument == null)
                {
                    return BadRequest();
                }


                var result = await _customerOtherDocumentDataService.EditCustomerOtherDocument(customerotherdocument);
                return Ok(result);



            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error saving data");
            }
        }
        [HttpGet("DeleteCustomerOtherDocument/{ID}")]
        public async Task<ActionResult<int>> DeleteCustomerOtherDocument([FromRoute] int ID)
        {
            try
            {
                if (ID ==0)
                {
                    return BadRequest();
                }


                var result = await _customerOtherDocumentDataService.DeleteCustomerOtherDocument(ID);
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
   

