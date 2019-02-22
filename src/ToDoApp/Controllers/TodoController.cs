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
    public class TodoController : Controller
    {
        private readonly ITodoAppService _appService;
        private readonly TodoValidator _validator;

        public TodoController(ITodoAppService appService, TodoValidator validator)
        {
            _appService = appService;
            _validator = validator;
        }

        // GET: api/todo
        [HttpGet]
        public Results.GenericResult<IEnumerable< TodoDto>> Get([FromQuery] TodoFilterDto filter)
        {
            var result = new Results.GenericResult<IEnumerable<TodoDto>>();
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

        // GET api/todo/5
        [HttpGet("{id}")]
        public Results.GenericResult<TodoDto> Get(int id)
        {
            var result = new Results.GenericResult<TodoDto>();
            try
            {
                result.Result = _appService.GetById(id);
                result.Success = true;
            }
            catch (Exception ex)
            {

                result.Errors = new[] { ex.Message };
            }

            return result;
             
        }

        // POST api/todo
        [HttpPost]
        public Results.GenericResult<TodoDto> Post([FromBody] TodoDto model)
        {
            var result = new Results.GenericResult<TodoDto>();
            var validatorResult = _validator.Validate(model);
            if (validatorResult.IsValid)
            {
                try
                {
                    result.Result = _appService.CreateTodo(model);
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

        // PUT api/todo/5
        [HttpPut("{id}")]
        public Results.GenericResult Put(int id, [FromBody]TodoDto model)
        {
            var result = new Results.GenericResult<TodoDto>();
            var validatorResult = _validator.Validate(model);
            if (validatorResult.IsValid)
            {
                try
                {
                     
                    result.Success = _appService.Update(model);
                    if (!result.Success)
                    {
                        throw new Exception($"Todo {id} can't be updated!");
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
        public Results.GenericResult Delete(int id)
        {
            var result = new Results.GenericResult {Success = _appService.Delete(id)};
            try
            {

                result.Success = _appService.Delete(id);
                if (!result.Success)
                {
                    throw new Exception($"Todo {id} can't be deleted!");
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
