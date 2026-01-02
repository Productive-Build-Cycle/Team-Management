using TeamManagement.Application.Abstraction;
using TeamManagement.Application.Abstraction.CQRS;
using TeamManagement.Application.Exceptions;

namespace TeamManagement.Application.Commands.AddMember;

public sealed class AddMemberCommandHandler : ICommandHandler<AddMemberCommand>
{
    private readonly ITeamRepository _teamRepository;
    public AddMemberCommandHandler(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task HandleAsync(AddMemberCommand command, CancellationToken cancellationToken)
    {
        var team = await _teamRepository.GetByIdAsync(command.TeamId, cancellationToken);
        if (team is null)
            throw new NotFoundException();
        team.AddMember(command.UserId);
        // TODO
        await _teamRepository.SaveChangeAsync(cancellationToken);
    }
}