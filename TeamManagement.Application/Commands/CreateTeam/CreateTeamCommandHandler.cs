using TeamManagement.Application.Abstraction;
using TeamManagement.Application.Abstraction.CQRS;
using TeamManagement.Application.Exceptions;
using TeamManagement.Application.OperationResult;
using TeamManagement.Domain.Aggregates;
using TeamManagement.Domain.ValueObjects;

namespace TeamManagement.Application.Commands.CreateTeam;

public sealed class CreateTeamCommandHandler : ICommandHandler<CreateTeamCommand, TeamId>
{
    private readonly ITeamRepository _teamRepository;

    public CreateTeamCommandHandler(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task<Result<TeamId>> HandleAsync(CreateTeamCommand command, CancellationToken cancellationToken)
    {

        var exists = await _teamRepository.ExistsByNameAsync(command.Name, cancellationToken);

        if (exists)
        {
            //throw new TeamNameAlreadyExistsException(command.Name);
            return Result<TeamId>.Fail(new Error($"{command.Name} is already exist!", ResultErrorCodeType.Duplicate));
        }

        var newTeamId = TeamId.Create(Guid.NewGuid());
        var newTeam = new Team(newTeamId, command.Name);

        await _teamRepository.AddAsync(newTeam, cancellationToken);
        var saveRes = await _teamRepository.SaveChangeAsync(cancellationToken);

        return saveRes > 0 ? Result<TeamId>.Success(newTeamId)
            : Result<TeamId>.Fail(new Error("Insert Fails", ResultErrorCodeType.DatabaseDidNotChange));
    }
}