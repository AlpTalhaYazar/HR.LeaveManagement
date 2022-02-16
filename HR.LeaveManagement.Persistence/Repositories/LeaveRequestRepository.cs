using HR.LeaveManagement.Application.Persistance.Contracts;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly HRLeaveManagementDbContext _dbContext;

        public LeaveRequestRepository(HRLeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<LeaveRequest>> GetLeaveRequestsWithDetailsAsync()
        {
            var leaveRequests = await _dbContext.LeaveRequests
                .Include(x => x.LeaveType)
                .ToListAsync();

            return leaveRequests;
        }

        public Task<List<LeaveRequest>> GetLeaveRequestWithDetailsByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetailsByIdAsync(int id)
        {
            var leaveRequest = await _dbContext.LeaveRequests
                .Include(x => x.LeaveType)
                .FirstOrDefaultAsync(x => x.Id == id);

            return leaveRequest;
        }

        public async Task ChangeApprovalStatusAsync(LeaveRequest leaveRequest, bool? ApprovalStatus)
        {
            leaveRequest.IsApproved = ApprovalStatus;
            _dbContext.Entry(leaveRequest).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
