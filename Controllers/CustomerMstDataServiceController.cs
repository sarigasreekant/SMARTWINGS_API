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
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CustomerMstDataServiceController : ControllerBase
    {
        private readonly ICustomer_mstDataService _customer_mstDataService;
        private readonly ILogger<CustomerMstDataServiceController> _logger;
        public CustomerMstDataServiceController(ICustomer_mstDataService customer_mstDataService, ILogger<CustomerMstDataServiceController> logger)
        {
            this._customer_mstDataService = customer_mstDataService;
            _logger = logger;
        }
        [HttpGet("GetCustomer")]
        public async Task<ActionResult<IEnumerable<Customer_mst>>> GetCustomer()
        {

            try
            {
                var result = await _customer_mstDataService.GetCustomer();

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
        [HttpGet("GetCustomerByID/{Custcode}")]
        public async Task<ActionResult<Customer_mst>> GetCustomerByID([FromRoute] string Custcode)
        {
            try
            {
                var result = await _customer_mstDataService.GetCustomerByID(Custcode);

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
        [HttpPost]
        [Route("SaveCustomer")]
        public async Task<ActionResult<CustomerResponse>> SaveCustomer(CustomerDTO customerdoto)
        {
            try
            {
                if (customerdoto == null)
                {
                    return BadRequest();
                }
                var customerReseponse = new CustomerResponse();
                using (DalSession dalSession = new DalSession())
                {
                    UnitOfWork unitOfWork = dalSession.UnitOfWork;
                    try
                    {
                        unitOfWork.BeginTransaction();
                        CustomerTransactionDataService _customer = new CustomerTransactionDataService(dalSession.UnitOfWork);
                         customerReseponse = await _customer.SaveCustomer(customerdoto);
                        unitOfWork.CommitTransaction();
                        return Ok(customerReseponse);
                    }
                    catch (Exception)
                    {
                        unitOfWork.RollbackTransaction();
                        return Ok(customerReseponse);
                    }
                }





            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error saving data");
            }
        }
        [HttpPost]
        [Route("EditCustomer")]
        public async Task<ActionResult<CustomerResponse>> EditCustomer(CustomerDTO customer_mst)
        {
            try
            {
                if (customer_mst == null)
                {
                    return BadRequest();
                }
                var customerReseponse = new CustomerResponse();

                using (DalSession dalSession = new DalSession())
                {
                    UnitOfWork unitOfWork = dalSession.UnitOfWork;
                    try
                    {
                        unitOfWork.BeginTransaction();
                        CustomerTransactionDataService _customer = new CustomerTransactionDataService(dalSession.UnitOfWork);
                        customerReseponse = await _customer.EditCustomer(customer_mst);
                        unitOfWork.CommitTransaction();
                        return Ok(customerReseponse);
                    }
                    catch (Exception)
                    {
                        unitOfWork.RollbackTransaction();
                        return Ok(customerReseponse);
                    }
                }



            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error saving data");
            }
        }
        [HttpGet("GetCustomer/{CustCode}/{Mobile}/{name}/{@Param}")]
        public async Task<ActionResult<IEnumerable<Customer_mst>>> Customer_mstSearch(string CustCode, string Mobile, string name, string @Param)
        {

            try
            {
                var result = await _customer_mstDataService.Customer_mstSearch(CustCode, Mobile, name, @Param);

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
        [HttpPost]
        [Route("CustSearch")]
        public async Task<ActionResult<IEnumerable<Customer_mst>>> Customer_mstSearchNew([FromBody] CustomerSearch customerSearch)
        {

            try
            {
                var result = await _customer_mstDataService.Customer_mstSearchNew(customerSearch);

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
