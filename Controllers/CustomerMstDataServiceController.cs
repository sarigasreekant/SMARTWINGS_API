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
                    return Ok("No such Customer");
                    //return NotFound();
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
        [HttpGet("GetCustomerByuserID/{userId}")]
        public async Task<ActionResult<Customer_mst>> GetCustomerByuserID([FromRoute] string userId)
        {
            try
            {
                var result = await _customer_mstDataService.GetCustomerByuserID(userId);

                if (result == null)
                {
                    return Ok("No such Customer");
                    //return NotFound();
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
        public async Task<ActionResult<CustomerResponse>> SaveCustomer(CustomerDTOMobile customerdoto)
        {
            try
            {
                if (customerdoto == null)
                {
                    return BadRequest();
                }
                var customerReseponse = new CustomerResponse();
                CustomerIdDetails iddetails=new CustomerIdDetails();
                UserMst userdetails = new UserMst();
                using (DalSession dalSession = new DalSession())
                {
                    UnitOfWork unitOfWork = dalSession.UnitOfWork;
                    
                    try
                    {
                        unitOfWork.BeginTransaction();
                        CustomerTransactionDataService _customer = new CustomerTransactionDataService(dalSession.UnitOfWork);
                        
                        customerReseponse = await _customer.SaveCustomer(customerdoto);
                        iddetails.Custcode = customerReseponse.CustomerCode;
                        iddetails.IssueContcode = customerdoto.IssueContcode;
                        iddetails.ExpDate=customerdoto.ExpDate;
                        iddetails.IdNo = customerdoto.IdNo;
                        iddetails.IdTypeCode = customerdoto.IdTypeCode;
                        var idresult=await _customer.SaveCustomerIdDetails(iddetails);
                        userdetails.OrgCode = SD.OrgCode;
                        userdetails.BranchCode = customerdoto.Branchcode;
                        userdetails.UserID = customerdoto.IdNo;
                        userdetails.Password = customerdoto.IdNo;
                        userdetails.Email = customerdoto.Mail;
                        userdetails.FullName=customerdoto.Name1 +" "+ customerdoto.Name2;
                        userdetails.UserGroup = 0;
                        userdetails.MobileNo = customerdoto.Cell1;
                        userdetails.ActiveFlag = "Y";
                        userdetails.VIPToken = "1234";
                        userdetails.CreatedDate= DateTime.Now;
                        var userresult=await _customer.SaveUser(userdetails);

                        unitOfWork.CommitTransaction();
                        return Ok(customerReseponse);
                    }
                    catch (Exception ex)
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
        //[HttpGet("GetCustomer/{CustCode}/{Mobile}/{name}/{@Param}")]
        //public async Task<ActionResult<IEnumerable<Customer_mst>>> Customer_mstSearch(string CustCode, string Mobile, string name, string @Param)
        //{

        //    try
        //    {
        //        var result = await _customer_mstDataService.Customer_mstSearch(CustCode, Mobile, name, @Param);

        //        if (result == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(result.ToList());
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //           "Error retrieving data from the database");
        //    }

        //}
        //[HttpPost]
        //[Route("CustSearch")]
        //public async Task<ActionResult<IEnumerable<Customer_mst>>> Customer_mstSearchNew([FromBody] CustomerSearch customerSearch)
        //{

        //    try
        //    {
        //        var result = await _customer_mstDataService.Customer_mstSearchNew(customerSearch);

        //        if (result == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(result.ToList());
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //           "Error retrieving data from the database");
        //    }

        //}
        [HttpGet("CheckNumberExistOrNot/{param1}/{param2}")]
        public async Task<ActionResult<string>> CheckNumberExistOrNot(string param1,string param2)
        {

            try
            {
                var result = await _customer_mstDataService.CheckNumberExistOrNot(param1,param2);

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
