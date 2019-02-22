using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace ToDoApp.Validators
{
    public class ReportValidator : AbstractValidator<AppServices.Dtos.ReportDto>
    {
        public ReportValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name field is required.");
        }
    }
}
