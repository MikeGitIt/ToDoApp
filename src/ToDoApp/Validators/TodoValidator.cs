using FluentValidation;

namespace ToDoApp.Validators
{
    public class TodoValidator : AbstractValidator<AppServices.Dtos.TodoDto>
    {
        public TodoValidator()
        {
            RuleFor(x => x.Text).NotNull().WithMessage("Text field is required.");
        }
    }
}
