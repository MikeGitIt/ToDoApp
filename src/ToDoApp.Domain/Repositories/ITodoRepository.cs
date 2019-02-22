using System.Collections.Generic;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Filters;

namespace ToDoApp.Domain.Repositories
{
    public interface ITodoRepository
    {
        Todo CreateTodo(Todo todo);
        IEnumerable<Todo> List(TodoFilter todoFilter);
        Todo GetById(int id);
        bool Update(Todo todo);
        bool Delete(int id);
    }
}
