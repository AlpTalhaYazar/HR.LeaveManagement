using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveTypesController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDto>>> GetLeaveTypesAsync()
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypeListRequest());
            return Ok(leaveTypes);
        }

        // GET api/<LeaveTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDto>> GetLeaveTypeWithDetailsByIdAsync(int id)
        {
            var leaveTypeWithDetails = await _mediator.Send(new GetLeaveTypeDetailRequest { Id = id });
            return Ok(leaveTypeWithDetails);
        }

        // POST api/<LeaveTypesController>
        [HttpPost]
        public async Task<ActionResult<LeaveTypeDto>> CreateLeaveTypeAsync([FromBody] CreateLeaveTypeDto createLeaveTypeDto)
        {
            var command = new CreateLeaveTypeCommand { LeaveTypeDto = createLeaveTypeDto };

            var createdLeaveType = await _mediator.Send(command);

            //return CreatedAtAction(nameof(GetLeaveTypeWithDetailsByIdAsync), new { id = createdLeaveType.Id }, createdLeaveType);
            //return Created($"api/LeaveTypes/{createdLeaveType.Id}", createdLeaveType);
            return CreatedAtAction(nameof(GetLeaveTypeWithDetailsByIdAsync), new {id = createdLeaveType.Id}, createdLeaveType);
        }

        // PUT api/<LeaveTypesController>
        [HttpPut]
        public async Task<ActionResult> UpdateLeaveTypeAsync([FromBody] LeaveTypeDto leaveTypeDto)
        {
            var command = new UpdateLeaveTypeCommand { LeaveTypeDto = leaveTypeDto };

            await _mediator.Send(command);

            return NoContent();
        }

        // DELETE api/<LeaveTypesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLeaveTypeAsync(int id)
        {
            var command = new DeleteLeaveTypeCommand { Id = id };

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
