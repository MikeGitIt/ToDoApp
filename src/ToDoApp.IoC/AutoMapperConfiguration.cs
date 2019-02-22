using System;
using System.Collections.Generic;

namespace ToDoApp.IoC
{
    public static class AutoMapperConfiguration
    {
        public static IEnumerable<Type> GetAutoMapperProfiles()
        {
            var result = new List<Type>();
            result.Add(typeof(AppServices.Mappings.MappingProfile));
            return result;
        }
    }
}
