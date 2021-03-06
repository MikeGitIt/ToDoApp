﻿using System.Collections.Generic;
using ToDoApp.AppServices.Dtos;
using ToDoApp.DomainServices.Interfaces;
using ToDoApp.AppServices.Extensions;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Filters;

namespace ToDoApp.AppServices
{
    internal class TodoAppService : Interfaces.ITodoAppService
    {
        private readonly ITodoDomainService service;

        public TodoAppService(ITodoDomainService service)
        {
            this.service = service;
        }
        public TodoDto CreateTodo(TodoDto todo)
        {
            var result = service.CreateTodo(todo.MapTo<Todo>());
            return result.MapTo<TodoDto>();
        }

        public bool Delete(int id)
        {
            return service.Delete(id);
        }

        public TodoDto GetById(int id)
        {
            return service.GetById(id).MapTo<TodoDto>();
        }

        public IEnumerable<TodoDto> List(TodoFilterDto todoFilter)
        {
            return service.List(todoFilter.MapTo<TodoFilter>()).EnumerableTo<TodoDto>();
        }

        public bool Update(TodoDto todo)
        {
            return service.Update(todo.MapTo<Todo>());
        }
    }
}
