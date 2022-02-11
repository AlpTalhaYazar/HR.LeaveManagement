using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Persistance.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<IReadOnlyList<LeaveRequest>> GetLeaveRequestsWithDetailsAsync();
        Task<LeaveRequest> GetLeaveRequestWithDetailsByIdAsync(int id);
    }
}
