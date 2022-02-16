using FluentValidation;
using HR.LeaveManagement.Application.Persistance.Contracts;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public ILeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(x => x.NumberOfDays)
                .GreaterThan(0)
                    .WithMessage("{PropertyName} has to be greater than 0.");

            RuleFor(x => x.Period)
                .GreaterThanOrEqualTo(DateTime.Now.Year)
                    .WithMessage("{PropertyName} has to be greater than 0.");

            RuleFor(x => x.LeaveTypeId)
                .GreaterThan(0)
                    .WithMessage("{PropertyName} has to be greater than 0.")
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeIdExists = await _leaveTypeRepository.IsExist(id);
                    return !leaveTypeIdExists;
                })
                .WithMessage("{PropertyName} does not exist.");
        }
    }
}