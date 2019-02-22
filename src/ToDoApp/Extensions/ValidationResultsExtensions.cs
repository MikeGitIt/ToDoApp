using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace ToDoApp.Extensions
{
    public static class ValidationResultsExtensions
    {
        public static string[] GetErrors(this ValidationResult validationResult)
        {
            var result = new List<string>();

            if (validationResult?.Errors == null) return result.ToArray();
            result.AddRange(validationResult.Errors.Select(error => error.ErrorMessage));

            return result.ToArray();
        }
    }
}
