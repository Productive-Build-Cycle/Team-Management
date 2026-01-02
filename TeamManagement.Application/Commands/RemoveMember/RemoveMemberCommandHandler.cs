using TeamManagement.Application.Abstraction;
using TeamManagement.Application.Abstraction.CQRS;
using TeamManagement.Application.Exceptions;

namespace TeamManagement.Application.Commands.RemoveMember;

public sealed class RemoveMemberCommandHandler : ICommandHandler<RemoveMemberCommand>
{
    private readonly ITeamRepository _teamRepository;

    public RemoveMemberCommandHandler(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task HandleAsync(RemoveMemberCommand command, CancellationToken cancellationToken)
    {
        var team = await _teamRepository.GetByIdAsync(command.TeamId, cancellationToken);

        if (team is null)
            throw new NotFoundException();

        team.RemoveMember(command.UserId);

        // TODO
        await _teamRepository.SaveChangeAsync(cancellationToken);
    }
}