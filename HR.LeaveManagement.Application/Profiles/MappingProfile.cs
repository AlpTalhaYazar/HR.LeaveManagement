using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region LeaveRequest
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
            CreateMap<CreateLeaveRequestDto, LeaveRequest>();
            CreateMap<UpdateLeaveRequestDto, LeaveRequest>();
            #endregion

            #region LeaveAllocation
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<CreateLeaveAllocationDto, LeaveAllocation>();
            CreateMap<UpdateLeaveAllocationDto, LeaveAllocation>();
            #endregion

            #region LeaveType
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<CreateLeaveTypeDto, LeaveType>();
            #endregion

        }
    }
}