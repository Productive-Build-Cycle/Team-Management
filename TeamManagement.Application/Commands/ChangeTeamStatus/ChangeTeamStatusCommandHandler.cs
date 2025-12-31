using Application.Abstractions;
using Application.Abstractions.CQRS;
using Application.Exceptions;

namespace Application.Commands.ChangeTeamStatus:

public sealed class ChangeTeamStatusCommandHandler:ICommandHandler<ChangeTeamStatusCommand>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IIdentityService _identityService;

    public ChangeTeamStatusCommandHandler(
        ITeamRepository teamRepository,
        IIdentityService identityService)
    {
        _teamRepository = teamRepository;
        _identityService = identityService;
    }

    public async Task HandleAsync(
        ChangeTeamStatusCommand command,
        CancellationToken cancellationToken)
    {
        if (!_identityService.IsAuthenticated)
            throw new UnauthorizedAccessException();

        var team = await _teamRepository.GetByIdAsync(
            command.TeamId,
            cancellationToken);

        if (team is null)
            throw new TeamNotFoundException(command.TeamId);

        team.ChangeStatus(command.NewStatus);

        await _teamRepository.AddAsync(team, cancellationToken);
    }
}
