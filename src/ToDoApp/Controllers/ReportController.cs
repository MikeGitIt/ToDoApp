using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.AppServices.Dtos;
using ToDoApp.AppServices.Interfaces;
using ToDoApp.Extensions;
using ToDoApp.Validators;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    public class ReportController : Controller
    {
        private readonly IReportAppService _appService;
        private readonly ReportValidator _validator;

        public ReportController(IReportAppService appService, ReportValidator validator)
        {
            _appService = appService;
            _validator = validator;
        }

        // GET: api/report
        [HttpGet]
        public Results.GenericResult<IEnumerable< ReportDto>> Get([FromQuery] ReportFilterDto filter)
        {
            var result = new Results.GenericResult<IEnumerable<ReportDto>>();
                try
                {
                    result.Result = _appService.List(filter);
                    result.Success = true;
                }
                catch (Exception ex)
                {

                    result.Errors = new[] { ex.Message };
                }

            return result;
            
        }

        // GET api/report/reportname.rdl
        [HttpGet("{name}")]
        public Results.GenericResult<ReportDto> Get(string name)
        {
            var result = new Results.GenericResult<ReportDto>();
            try
            {
                result.Result = _appService.GetByName(name);
                result.Success = true;
            }
            catch (Exception ex)
            {

                result.Errors = new[] { ex.Message };
            }

            return result;
             
        }

        // POST api/report
        [HttpPost]
        public Results.GenericResult<ReportDto> Post([FromBody] ReportDto model)
        {
            var result = new Results.GenericResult<ReportDto>();
            var validatorResult = _validator.Validate(model);
            if (validatorResult.IsValid)
            {
                try
                {
                    result.Result = _appService.CreateReport(model);
                    result.Success = true;
                }
                catch (Exception ex)
                {

                    result.Errors = new[] { ex.Message };
                }
            }

            else
                result.Errors = validatorResult.GetErrors();
            return result;
        }

        // PUT api/report/5
        [HttpPut("{name}")]
        public Results.GenericResult Put(int id, [FromBody]ReportDto model)
        {
            var result = new Results.GenericResult<ReportDto>();
            var validatorResult = _validator.Validate(model);
            if (validatorResult.IsValid)
            {
                try
                {
                     
                    result.Success = _appService.Update(model);
                    if (!result.Success)
                    {
                        throw new Exception($"Report {id} can't be updated!");
                    }
                }
                catch (Exception ex)
                {

                    result.Errors = new[] { ex.Message };
                }
            }

            else
                result.Errors = validatorResult.GetErrors();
            return result;
        }

        // DELETE api/todo/5
        [HttpDelete("{id}")]
        public Results.GenericResult Delete(string name)
        {
            var result = new Results.GenericResult {Success = _appService.Delete(name)};
            try
            {

                result.Success = _appService.Delete(name);
                if (!result.Success)
                {
                    throw new Exception($"Todo {name} can't be deleted!");
                }
            }
            catch (Exception ex)
            {

                result.Errors = new[] { ex.Message };
            }
            return result;
        }
    }
}
