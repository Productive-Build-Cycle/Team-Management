using Endpoint.Rest.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TeamManagement.Application.Abstraction;
using TeamManagement.Application.Commands.AddMember;
using TeamManagement.Application.Commands.AssignLeader;
using TeamManagement.Application.Commands.ChangeTeamStatus;
using TeamManagement.Application.Commands.CreateTeam;
using TeamManagement.Application.Commands.RemoveMember;

namespace Endpoint.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamFacade _teamFacade;

        public TeamController(ITeamFacade teamFacade)
        {
            _teamFacade = teamFacade;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTeamRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateTeamCommand(
                request.Name
            );

            await _teamFacade.CreateTeamAsync(command, cancellationToken);

            return Created();
        }

        [HttpPost("{id:guid}/members")]
        public async Task<IActionResult> AddMember(Guid id, [FromBody] AddTeamMemberRequest request, CancellationToken cancellationToken)
        {
            var command = new AddMemberCommand(id, request.MemberId);

            await _teamFacade.AddMemberAsync(command, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id:guid}/members")]
        public async Task<IActionResult> RemoveMember(Guid id, [FromBody] RemoveTeamMemberRequest request, CancellationToken cancellationToken)
        {
            var command = new RemoveMemberCommand(id, request.UserId);

            await _teamFacade.RemoveMemberAsync(command, cancellationToken);

            return NoContent();
        }

        [HttpPut("{id:guid}/leader")]
        public async Task<IActionResult> AssignTeamLeader(Guid id, [FromBody] AssignTeamLeaderRequest request, CancellationToken cancellationToken)
        {
            var command = new AssignLeaderCommand(id, request.MemberId);

            await _teamFacade.AssignLeaderAsync(command, cancellationToken);

            return NoContent();
        }

        [HttpPut("{id:guid}/status")]
        public async Task<IActionResult> ChangeStatus(Guid id, [FromBody] ChangeTeamStatusRequest request, CancellationToken cancellationToken)
        {
            var command = new ChangeTeamStatusCommand(id, request.NewStatus);

            await _teamFacade.ChangeStatusAsync(command, cancellationToken);

            return NoContent();
        }
    }
}
