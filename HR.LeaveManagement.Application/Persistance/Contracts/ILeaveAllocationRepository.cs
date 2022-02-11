﻿using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Persistance.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<IReadOnlyList<LeaveAllocation>> GetLeaveAllocationsWithDetailsAsync();
        Task<LeaveAllocation> GetLeaveAllocationWithDetailsByIdAsync(int id);
    }
}
