using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class ILeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public ILeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(x => x.StartDate)
                .LessThan(x => x.EndDate)
                    .WithMessage("{PropertyName} must be before {ComparisonValue}.");

            RuleFor(x => x.EndDate)
                .GreaterThan(x => x.StartDate)
                    .WithMessage("{PropertyName} must be after {ComparisonValue}.");

            RuleFor(x => x.LeaveTypeId)
                .GreaterThan(0)
                    .WithMessage("{PropertyName} has to be greater than 0.")
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeIdExists = await _leaveTypeRepository.IsExist(id);
                    return !leaveTypeIdExists;

                }).WithMessage("{PropertyName} does not exist.");
        }

    }
}
