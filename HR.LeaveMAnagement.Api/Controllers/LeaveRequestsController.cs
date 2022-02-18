using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        // GET: api/<LeaveRequestsController>
        public LeaveRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestListDto>>> GetLeaveRequestsAsync()
        {
            var leaveRequests = await _mediator.Send(new GetLeaveRequestListRequest());

            return Ok(leaveRequests);
        }

        // GET api/<LeaveRequestsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDto>> GetLeaveRequestWithDetailsByIdAsync(int id)
        {
            var leaveRequestWithDetail = await _mediator.Send(new GetLeaveRequestDetailRequest { Id = id });

            return Ok(leaveRequestWithDetail);
        }

        // POST api/<LeaveRequestsController>
        [HttpPost]
        public async Task<ActionResult<LeaveRequestDto>> CreateLeaveRequestAsync([FromBody] CreateLeaveRequestDto createLeaveRequestDto)
        {
            var command = new CreateLeaveRequestCommand { CreateLeaveRequestDto = createLeaveRequestDto };

            var createdLeaveRequest = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetLeaveRequestWithDetailsByIdAsync), new { id = createdLeaveRequest.Id });
        }

        // PUT api/<LeaveRequestsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLeaveRequestAsync(int id, [FromBody] UpdateLeaveRequestDto updateLeaveRequestDto)
        {
            var command = new UpdateLeaveRequestCommand
            {
                Id = id, 
                UpdateLeaveRequestDto = updateLeaveRequestDto
            };

            await _mediator.Send(command);

            return NoContent();
        }
        // PUT api/<LeaveRequestsController>/ChangeApproval/5
        [HttpPut("ChangeApproval/{id}")]
        public async Task<ActionResult> ChangeApprovalAsync(int id, [FromBody] ChangeLeaveRequestApprovalDto approvalDto)
        {
            var command = new UpdateLeaveRequestCommand
            {
                Id = id,
                ChangeLeaveRequestApprovalDto = approvalDto
            };

            await _mediator.Send(command);

            return NoContent();
        }

        // DELETE api/<LeaveRequestsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLeaveRequestAsync(int id)
        {
            var command = new DeleteLeaveRequestCommand { Id = id };

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
