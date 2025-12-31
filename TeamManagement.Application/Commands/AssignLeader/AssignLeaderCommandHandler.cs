using Application.Abstractions;
using Application.Abstractions.CQRS;
using Application.Exceptions;

namespace Application.Commands.AssignLeader
{
public sealed class AssignLeaderCommandHandler
    : ICommandHandler<AssignLeaderCommand>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IIdentityService _identityService;

    public AssignLeaderCommandHandler(
        ITeamRepository teamRepository,
        IIdentityService identityService)
    {
        _teamRepository = teamRepository;
        _identityService = identityService;
    }

    public async Task HandleAsync(
        AssignLeaderCommand command,
        CancellationToken cancellationToken)
    {
        if (!_identityService.IsAuthenticated)
            throw new UnauthorizedAccessException();

        var team = await _teamRepository.GetByIdAsync(
            command.TeamId,
            cancellationToken);

        if (team is null)
            throw new TeamNotFoundException(command.TeamId);

        team.AssignLeader(command.LeaderId);

        await _teamRepository.AddAsync(team, cancellationToken);
    }
}

}

