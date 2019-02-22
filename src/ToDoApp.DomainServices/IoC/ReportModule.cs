using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.DomainServices.IoC
{
    public class ReportModule
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dictionary = new Dictionary<Type, Type>();
            dictionary.Add(typeof(Interfaces.IReportDomainService), typeof(ReportDomainService));
            return dictionary;
        }
    }
}
