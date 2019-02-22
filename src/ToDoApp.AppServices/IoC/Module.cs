using System;
using System.Collections.Generic;

namespace ToDoApp.AppServices.IoC
{
    public static class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dic = new Dictionary<Type, Type>
            {
                {typeof(Interfaces.ITodoAppService), typeof(TodoAppService)},
                {typeof(Interfaces.IReportAppService), typeof(ReportAppService)}
            };
            return dic;
        }
    }
}
