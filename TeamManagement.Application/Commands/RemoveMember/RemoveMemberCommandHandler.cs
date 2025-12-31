using Application.Abstractions;
using Application.Abstractions.CQRS;
using Application.Exceptions;

namespace Application.Commands.RemoveMember;

public sealed class RemoveMemberCommandHandler
    : ICommandHandler<RemoveMemberCommand>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IIdentityService _identityService;

    public RemoveMemberCommandHandler(
        ITeamRepository teamRepository,
        IIdentityService identityService)
    {
        _teamRepository = teamRepository;
        _identityService = identityService;
    }

    public async Task HandleAsync(
        RemoveMemberCommand command,
        CancellationToken cancellationToken)
    {
        if (!_identityService.IsAuthenticated)
            throw new UnauthorizedAccessException();

        var team = await _teamRepository.GetByIdAsync(
            command.TeamId,
            cancellationToken);

        if (team is null)
            throw new TeamNotFoundException(command.TeamId);

        team.RemoveMember(command.MemberId);

        await _teamRepository.AddAsync(team, cancellationToken);
    }
}
