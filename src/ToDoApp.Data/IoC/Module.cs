using System;
using System.Collections.Generic;

namespace ToDoApp.Data.IoC
{
    public static class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dictionary = new Dictionary<Type, Type>
            {
                {typeof(Domain.Repositories.ITodoRepository), typeof(Repositories.TodoRepository)},
                {typeof(Domain.Repositories.IReportRepository), typeof(Repositories.ReportRepository)}
            };
            return dictionary;
        }
    }
}
