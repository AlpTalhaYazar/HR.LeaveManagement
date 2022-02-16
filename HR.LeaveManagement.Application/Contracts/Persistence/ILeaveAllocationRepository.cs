using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<IReadOnlyList<LeaveAllocation>> GetLeaveAllocationsWithDetailsAsync();
        Task<LeaveAllocation> GetLeaveAllocationWithDetailsByIdAsync(int id);
    }
}
