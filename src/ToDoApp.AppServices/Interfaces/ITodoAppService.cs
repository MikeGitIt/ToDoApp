using System.Collections.Generic;
using ToDoApp.AppServices.Dtos;

namespace ToDoApp.AppServices.Interfaces
{
    public interface ITodoAppService
    {
        TodoDto CreateTodo(TodoDto todo);
        IEnumerable<TodoDto> List(TodoFilterDto todoFilter);
        TodoDto GetById(int id);
        bool Update(TodoDto todo);
        bool Delete(int id);
    }
}
