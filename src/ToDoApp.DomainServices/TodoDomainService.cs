using System.Collections.Generic;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Filters;
using ToDoApp.Domain.Repositories;
using ToDoApp.DomainServices.Interfaces;

namespace ToDoApp.DomainServices
{
    internal class TodoDomainService : ITodoDomainService
    {
        private ITodoRepository repository;

        public TodoDomainService(ITodoRepository repository)
        {
            this.repository = repository;
        }
        public Todo CreateTodo(Todo todo)
        {
            return repository.CreateTodo(todo);
        }

        public IEnumerable<Todo> List(TodoFilter todoFilter)
        {
            return repository.List(todoFilter);
        }

        public Todo GetById(int id)
        {
            return repository.GetById(id);
        }

        public bool Update(Todo todo)
        {
            return repository.Update(todo);
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }
    }
}
