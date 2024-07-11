using ForexDataService;
using ForexModel;
using Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DHBForexAPI
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserMstDataServiceController : ControllerBase
    {
        private readonly IUserMstDataService _userMstDataService;
        private readonly ILogger<UserMstDataServiceController> _logger;
        public UserMstDataServiceController(IUserMstDataService userMstDataService, ILogger<UserMstDataServiceController> logger)
        {
            this._userMstDataService = userMstDataService;
            _logger = logger;
        }

      
       
        [HttpGet("GetUserByID/{UserID}")]
        public async Task<ActionResult<UserMst>> GetUserByID(string UserID)
        {

            try
            {
                var result = await _userMstDataService.GetUserByID(UserID);

                if (result == null)
                {
                    UserMst varnull = new UserMst();
                    varnull.IsScucess = false;
                    //return Ok(varnull);
                    return Ok("No such User");
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
        //[HttpPost("SaveUser")]
        //public async Task<ActionResult<int>> SaveUser(UserMst user)
        //{
        //    try
        //    {
        //        if (user == null)
        //        {
        //            return BadRequest();
        //        }


        //        var result = await _userMstDataService.SaveUser(user);
        //        return Ok(result);



        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //           "Error saving data");
        //    }
        //}
        //[HttpPost("DeleteUser")]
        //public async Task<ActionResult<int>> DeleteUser(string UserID)
        //{
        //    try
        //    {
        //        if (UserID == null)
        //        {
        //            return BadRequest();
        //        }


        //        var result = await _userMstDataService.DeleteUser(UserID);
        //        return Ok(result);



        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //           "Error saving data");
        //    }
        //}
       
        [HttpGet("Login/{UserId}/{Password}")]
        [AllowAnonymous]
        public async Task<ActionResult<UserMst>> Login(string UserId, string Password)
        {

            try
            {
                var result = await _userMstDataService.Login(UserId, Password);

                if (result == null)
                {
                    UserMst varnull = new UserMst();
                    varnull.IsScucess = false;
                    var message= "Username Or Password is Incorrect";
                    return Ok(message);
                    //return Ok(varnull);
                }
                string Token = JwtAuthenticationManager.GenerateJwtToken(result);
                result.JWTToken = Token;
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }

        }
        [HttpGet("UpdatePassowrdUser/{UserId}/{Password}")]
        public async Task<ActionResult<int>> UpdatePassowrdUser(string UserId, string Password)
        {

            try
            {
                var result = await _userMstDataService.UpdatePassowrdUser(UserId, Password);

                if (result == 0)
                {
                    return Ok(result);
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
        //[HttpGet("MenuPermitted/{MenuID}/{UserGroup}")]
        //[AllowAnonymous]
        //public async Task<ActionResult<bool>> IsMenuPermitted([FromRoute] string MenuID, string UserGroup)
        //{

        //    try
        //    {
        //        if (String.IsNullOrEmpty(MenuID))
        //            MenuID = "0";
        //        if (String.IsNullOrEmpty(UserGroup))
        //            UserGroup = "0";
        //        var result = await _userMstDataService.IsMenuPermitted(Convert.ToInt32(MenuID), UserGroup);

        //        if (result == false)
        //        {
        //            return Ok(false);
        //        }

        //        return Ok(true);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //           "Error retrieving data from the database");
        //    }

        //}
        [HttpGet("TwoFactorAut/{UserId}/{Viptoken}")]
        public async Task<ActionResult<string>> TwoFactorAut([FromRoute] string UserId, string Viptoken)
        {

            try
            {
                bool value = await _userMstDataService.IsValidToken(UserId, Viptoken);
                string retrunvale = "";
                if (value)
                    retrunvale = "Sucess";
                else
                    retrunvale = "Not Found";
                return Ok(retrunvale);
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
