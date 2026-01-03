using TeamManagement.Domain.Aggregates;

namespace TeamManagement.Application.Abstraction;

public interface ITeamRepository
{
    Task AddAsync(Team team, CancellationToken cancellationToken);
    Task<Team?> GetByIdAsync(Guid teamId, CancellationToken cancellationToken);
    Task<Team?> GetByNameAsync(string name, CancellationToken cancellationToken);
    Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken);
    Task<int> SaveChangeAsync(CancellationToken cancellationToken);
}