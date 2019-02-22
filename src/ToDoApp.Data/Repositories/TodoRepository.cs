using System.Collections.Generic;
using Dapper;
using Microsoft.Extensions.Configuration;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Filters;

namespace ToDoApp.Data.Repositories
{
    internal class TodoRepository : RepositoryBase, Domain.Repositories.ITodoRepository
    {
        public TodoRepository(IConfigurationRoot configuration) : base(configuration)
        {
        }

        public Todo CreateTodo(Todo todo)
        {
            todo.Id = connection.QueryFirst<int>("exec todo_sp_create @Text, @IsCompleted", todo);
            return todo;
        }

        public IEnumerable<Todo> List(TodoFilter todoFilter)
        {
            var result = connection.Query<Todo>("exec todo_sp_list", todoFilter);
            return result;
        }

        public Todo GetById(int id)
        {
            var result = connection.QueryFirstOrDefault<Todo>("exec todo_sp_get @Id", new {Id = id});
            return result;
        }

        public bool Update(Todo todo)
        {
            var affecteRows = connection.Execute("exec todo_sp_update @Id, @Text, @IsCompleted", todo);
            return affecteRows > 0;
        }

        public bool Delete(int id)
        {
            var affectedRows = connection.Execute("exec todo_sp_delete @Id", new {Id = id});
            return affectedRows > 0;
        }
    }
}
