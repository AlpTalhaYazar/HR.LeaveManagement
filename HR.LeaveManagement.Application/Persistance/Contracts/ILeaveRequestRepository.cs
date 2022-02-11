﻿using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Persistance.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<IReadOnlyList<LeaveRequest>> GetLeaveRequestsWithDetailsAsync();
        Task<List<LeaveRequest>> GetLeaveRequestWithDetailsByIdAsync(string id);
        Task<LeaveRequest> GetLeaveRequestWithDetailsByIdAsync(int id);
        Task ChangeApprovalStatusAsync(LeaveRequest leaveRequest, bool? ApprovalStatus);
    }
}
