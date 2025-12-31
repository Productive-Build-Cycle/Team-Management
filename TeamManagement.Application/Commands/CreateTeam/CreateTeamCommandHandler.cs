using Application.Abstractions;
using Application.Abstractions.CQRS;
using Application.Exceptions;

namespace Application.Commands.CreateTeam;

public sealed class CreateTeamCommandHandler : ICommandHandler<CreateTeamCommand>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IIdentityService _identityService;

    public CreateTeamCommandHandler(
        ITeamRepository teamRepository,
        IIdentityService identityService)
    {
        _teamRepository = teamRepository;
        _identityService = identityService;
    }

    public async Task HandleAsync(
        CreateTeamCommand command,
        CancellationToken cancellationToken)
    {
        if (!_identityService.IsAuthenticated)
            throw new UnauthorizedAccessException();

        var exists = await _teamRepository.ExistsByNameAsync(
            command.Name,
            cancellationToken);

        if (exists)
            throw new TeamNameAlreadyExistsException(command.Name);

        var ownerId = _identityService.UserId;

        var team = Team.Create(
            command.Name,
            ownerId
        );

        await _teamRepository.AddAsync(team, cancellationToken);
    }
}
