using Application.Abstrations;
using Application.Abstractions.CQRS;
using Application.Exceptions;

namespace Application.Cmmands.AddMember;


public sealed class AddMemberCommandHandler:ICommandHandler<AddMemberCommand>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IIdentityService _IdentityService;
    public AddMemberCommandHandler(ITeamRepository teamRepository,IIdentityService identityService)
    {
        _teamRepository = teamRepository;
        _IdentityService = identityService;
    }
    public async Task HandleAsync(
        AddMemberCommand command,CancellationToken cancellationToken
        )
    {
        if (!_IdentityService.IsAuthenticated) 
        throw new UnauthorizedAccessExceotion();
        var team= await _teamRepository.GetByIdAsync(command.TeamId,cancellationToken);
        if (team is null)
            throw new TeamNotFoundException(command.TeamId);
        team.AddMemeber(command.MemeberId);
        await _teamRepository.AddAsync(team,cancellationToken);

    }
}

