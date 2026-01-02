using TeamManagement.Application.Abstraction;
using TeamManagement.Application.Abstraction.CQRS;
using TeamManagement.Application.Exceptions;
using TeamManagement.Domain.Aggregates;
using TeamManagement.Domain.ValueObjects;

namespace TeamManagement.Application.Commands.CreateTeam;

public sealed class CreateTeamCommandHandler : ICommandHandler<CreateTeamCommand>
{
    private readonly ITeamRepository _teamRepository;

    public CreateTeamCommandHandler(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task HandleAsync(CreateTeamCommand command, CancellationToken cancellationToken)
    {

        var exists = await _teamRepository.ExistsByNameAsync(command.Name, cancellationToken);

        if (exists)
            throw new TeamNameAlreadyExistsException(command.Name);

        var newTeamId = TeamId.Create(Guid.NewGuid());
        var newTeam = new Team(newTeamId, command.Name);

        await _teamRepository.AddAsync(newTeam, cancellationToken);
        await _teamRepository.SaveChangeAsync(cancellationToken);
    }
}