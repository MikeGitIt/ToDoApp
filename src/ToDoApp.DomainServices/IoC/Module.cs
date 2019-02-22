using System;
using System.Collections.Generic;
using ToDoApp.DomainServices.Interfaces;

namespace ToDoApp.DomainServices.IoC
{
    public static class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dictionary = new Dictionary<Type, Type>
            {
                {typeof(ITodoDomainService), typeof(TodoDomainService)},
                {typeof(IReportDomainService), typeof(ReportDomainService)}
            };
            return dictionary;
        }
    }
}
