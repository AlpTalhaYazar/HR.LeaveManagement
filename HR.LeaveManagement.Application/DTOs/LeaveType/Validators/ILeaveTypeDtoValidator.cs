using FluentValidation;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class ILeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
    {
        public ILeaveTypeDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().NotEmpty()
                    .WithMessage("{PropertyName} is required.")
                .MaximumLength(50)
                    .WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(x => x.DefaultDays)
                .NotEmpty()
                    .WithMessage("{PropertyName} is required.")
                .GreaterThan(0)
                    .WithMessage("{PropertyName} should be greater than {ComparisonValue}.")
                .LessThan(100)
                    .WithMessage("{PropertyName} should be greater than {ComparisonValue}.");
        }
    }
}
