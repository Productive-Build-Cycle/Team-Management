using TeamManagement.Application.Abstraction;
using TeamManagement.Application.Abstraction.CQRS;
using TeamManagement.Application.Commands.AssignLeader;
using TeamManagement.Application.Exceptions;

namespace Application.Commands.AssignLeader
{
    public sealed class AssignLeaderCommandHandler : ICommandHandler<AssignLeaderCommand>
    {
        private readonly ITeamRepository _teamRepository;

        public AssignLeaderCommandHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task HandleAsync(
            AssignLeaderCommand command, CancellationToken cancellationToken)
        {
            var team = await _teamRepository.GetByIdAsync(command.TeamId, cancellationToken);

            if (team is null)
                throw new NotFoundException();
            
            team.AssignLeader(command.UserId);
            //TODO
            await _teamRepository.SaveChangeAsync(cancellationToken);
        }
    }
}