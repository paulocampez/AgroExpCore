﻿


// —————————————— 
// <auto-generated> 
//	This code was auto-generated 01/22/2021 05:38:44 
//     	T4 template generates controller's code
//	NOTE:T4 generated code may need additional updates/addjustments by developer in order to compile a solution.
// <auto-generated> 
// —————————————–
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using AgroExpCore.Domain;
using AgroExpCore.Entity.Context;
using AgroExpCore.Domain.Service;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Serilog;
using AgroExpCore.Entity;

namespace AgroExpCore.Api.Controllers
{
    /// <summary>
    ///    
    /// A Company controller
    ///
    /// MANUAL UPDATES REQUIRED!
    /// Update API version and uncomment route version declaration if required 
    ///       
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyService<CompanyViewModel, Company> _companyService;
        public CompanyController(CompanyService<CompanyViewModel, Company> companyService)
        {
            _companyService = companyService;
        }
		
	//get all
        [Authorize]
        [HttpGet]
        public IEnumerable<CompanyViewModel> GetAll()
        {
	    //Serilog log examples 
            //Log.Information("Log: Log.Information");
            //Log.Warning("Log: Log.Warning");
            //Log.Error("Log: Log.Error");
            //Log.Fatal("Log: Log.Fatal");
            var items = _companyService.GetAll();
            return items;
        }

        //get one
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _companyService.GetOne(id);
            if (item == null)
            {
                Log.Error("GetById({ ID}) NOT FOUND", id);
                return NotFound();
            }

            return Ok(item);
        }

        //add
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult Create([FromBody] CompanyViewModel company)
        {
            if (company == null)
                return BadRequest();

            var id = _companyService.Add(company);
            return Created($"api/Company/{id}", id);  //HTTP201 Resource created
        }

        //update
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CompanyViewModel company)
        {
            if (company == null || company.Id != id)
                return BadRequest();

	    var retVal = _companyService.Update(company);
            if (retVal == 0)
				return StatusCode(304);  //Not Modified
            else if (retVal == - 1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //412 Precondition Failed  - concurrency
            else
                return Accepted(company);
        }

        //delete 
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
	    var retVal = _companyService.Remove(id);
	    if (retVal == 0)
                return NotFound();  //Not Found 404
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //Precondition Failed  - concurrency
            else
                return NoContent();   	     //No Content 204
        }

    }

    /// <summary>
    ///    
    /// A Company controller
    ///
    /// MANUAL UPDATES REQUIRED!
    /// Update API version and uncomment route version declaration if required 
    ///       
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CompanyAsyncController : ControllerBase
    {
        private readonly CompanyServiceAsync<CompanyViewModel, Company> _companyServiceAsync;
        public CompanyAsyncController(CompanyServiceAsync<CompanyViewModel, Company> companyServiceAsync)
        {
            _companyServiceAsync = companyServiceAsync;
        }


        //get all
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _companyServiceAsync.GetAll();
            return Ok(items);
        }

        //get one
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _companyServiceAsync.GetOne(id);
            if (item == null)
            {
                Log.Error("GetById({ ID}) NOT FOUND", id);
                return NotFound();
            }

            return Ok(item);
        }

        //add
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompanyViewModel company)
        {
            if (company == null)
                return BadRequest();

            var id = await _companyServiceAsync.Add(company);
            return Created($"api/Company/{id}", id);  //HTTP201 Resource created
        }

        //update
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CompanyViewModel company)
        {
            if (company == null || company.Id != id)
                return BadRequest();

	    var retVal = await _companyServiceAsync.Update(company);
            if (retVal == 0)
				return StatusCode(304);  //Not Modified
            else if (retVal == - 1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //412 Precondition Failed  - concurrency
            else
                return Accepted(company);
        }


        //delete
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
	    var retVal = await _companyServiceAsync.Remove(id);
	    if (retVal == 0)
                return NotFound();  //Not Found 404
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //Precondition Failed  - concurrency
            else
                return NoContent();   	     //No Content 204
        }
    }
}