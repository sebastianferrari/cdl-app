using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebApplication.Data;
using WebApplication.Data.Entities;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LicensesController : ControllerBase
    {
        private readonly ICDLRepository _repository;
        private readonly ILogger<LicensesController> _logger;
        private readonly IMapper _mapper;

        public LicensesController(ICDLRepository repository, 
            ILogger<LicensesController> logger, 
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(400)]
        public IActionResult GetAll()
        //public ActionResult<IEnumerable<CustomerDriverLicense>> Get()
        {
            try
            {
                return Ok(
                    _mapper.Map<IEnumerable<CustomerDriverLicense>, IEnumerable<LicenseViewModel>>(_repository.GetAllLicenses()));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all Licenses: {ex}");
                return BadRequest("Failed to get all Licenses");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var license = _repository.GetLicenseById(id);

                if (license != null)
                {
                    _logger.LogInformation($"License found: {license}");
                    return Ok(_mapper.Map<CustomerDriverLicense, LicenseViewModel>(license));
                }
                else
                {
                    _logger.LogInformation($"License id #{id} not found:");
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all Licenses: {ex}");
                return BadRequest("Failed to get all Licenses");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]LicenseViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newLicense = _mapper.Map<LicenseViewModel, CustomerDriverLicense>(model);

                    _repository.AddEntity(newLicense);
                    if (_repository.SaveAll())
                    {
                        return Created($"/api/Licenses/{newLicense.ID}", _mapper.Map<CustomerDriverLicense, LicenseViewModel>(newLicense));
                    } 
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to save a new License: {ex}");
            }

            return BadRequest("Failed to save new License.");
        }
    }
}