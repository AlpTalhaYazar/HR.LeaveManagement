using FluentValidation;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class UpdateLeaveTypeDtoValidator : AbstractValidator<LeaveTypeDto>
    {
        public UpdateLeaveTypeDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("{PropertyName} must be present.");

            Include(new ILeaveTypeDtoValidator());
        }
    }
}
