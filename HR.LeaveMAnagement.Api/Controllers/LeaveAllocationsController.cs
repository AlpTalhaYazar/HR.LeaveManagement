using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        // GET: api/<LeaveAllocationsController>
        public LeaveAllocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDto>>> GetLeaveAllocationsAsync()
        {
            var leaveAllocations = await _mediator.Send(new GetLeaveAllocationListRequest());

            return Ok(leaveAllocations);
        }

        // GET api/<LeaveAllocationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDto>> GetLeaveAllocationWithDetailsByIdAsync(int id)
        {
            var leaveAllocationWithDetail = await _mediator.Send(new GetLeaveAllocationDetailRequest { Id = id });

            return Ok(leaveAllocationWithDetail);
        }

        // POST api/<LeaveAllocationsController>
        [HttpPost]
        public async Task<ActionResult<CreateLeaveAllocationDto>> CreateLeaveAllocationAsync([FromBody] CreateLeaveAllocationDto createLeaveAllocationDto)
        {
            var command = new CreateLeaveAllocationCommand { LeaveAllocationDto = createLeaveAllocationDto };

            var createdLeaveAllocation = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetLeaveAllocationWithDetailsByIdAsync),
                new { id = createdLeaveAllocation.Id });
        }

        // PUT api/<LeaveAllocationsController>
        [HttpPut]
        public async Task<ActionResult> UpdateLeaveAllocationAsync([FromBody] UpdateLeaveAllocationDto updateLeaveAllocationDto)
        {
            var command = new UpdateLeaveAllocationCommand { UpdateLeaveAllocationDto = updateLeaveAllocationDto };

            await _mediator.Send(command);

            return NoContent();
        }

        // DELETE api/<LeaveAllocationsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLeaveAllocationAsync(int id)
        {
            var command = new DeleteLeaveAllocationCommand { Id = id };

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
