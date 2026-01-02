using TeamManagement.Application.Abstraction;
using TeamManagement.Application.Abstraction.CQRS;
using TeamManagement.Application.Exceptions;
using TeamManagement.Core.Enum;

namespace TeamManagement.Application.Commands.ChangeTeamStatus;

public sealed class ChangeTeamStatusCommandHandler : ICommandHandler<ChangeTeamStatusCommand>
{
    private readonly ITeamRepository _teamRepository;

    public ChangeTeamStatusCommandHandler(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task HandleAsync(ChangeTeamStatusCommand command, CancellationToken cancellationToken)
    {
        var team = await _teamRepository.GetByIdAsync(command.TeamId, cancellationToken);

        if (team is null)
            throw new NotFoundException();

        if (command.NewStatus == TeamStatus.Active)
            team.Activate();
        else
            team.Archive();

        // TODO
        await _teamRepository.SaveChangeAsync(cancellationToken);
    }
}