﻿using DataAccess;
using ForexDataService;
using ForexModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QRCoder;

namespace DHBForexAPI
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RemServiceProfileController : ControllerBase
    {
        private readonly IRemServiceProfileDataService _remitServiceProfileDatatService;        
        private readonly ILogger<RemServiceProfileController> _logger;
        public RemServiceProfileController(IRemServiceProfileDataService remitServiceProfileDatatService, ILogger<RemServiceProfileController> logger)
        {
            this._remitServiceProfileDatatService = remitServiceProfileDatatService;
            _logger = logger;
        }

        [HttpGet("GetServiceProfile/{custcode}/{servcode}")]
        public async Task<ActionResult<IEnumerable<RemServiceProfile>>> GetServiceProfile([FromRoute] string custcode,string servcode)
        {

            try
            {
                var result = await _remitServiceProfileDatatService.GetServiceProfile(custcode,servcode);

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
        [HttpGet("GetServiceProfilebyId/{servno}")]
        public async Task<ActionResult<RemServiceProfile>> GetServiceProfilebyId([FromRoute] int servno)
        {
            try
            {
                var result = await _remitServiceProfileDatatService.GetServiceProfilebyId(servno);

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
        [Route("SaveServiceProf")]
        public async Task<ActionResult<CommanResponse>> SaveServiceProf(ServiceProfileDTO servdto)
        {
            try
            {
                if (servdto == null)
                {
                    return BadRequest();
                }
                var result = await _remitServiceProfileDatatService.SaveServiceProf(servdto);
                //return Ok("Success");
                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error saving data");
            }


        }
        [HttpGet("CheckAcNumberExistOrNot/{param1}/{param2}")]
        public async Task<ActionResult<string>> CheckAcNumberExistOrNot(string param1, string param2)
        {

            try
            {
                var result = await _remitServiceProfileDatatService.CheckAcNumberExistOrNot(param1, param2);

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
