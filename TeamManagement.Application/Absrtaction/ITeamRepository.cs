using System;

namespace Application.Abstractions;

public interface ITeamRepository
{
    task AddAsync(Team team, CancellationToken cancellationToken);
        Task<Team?> GetByIdAsync(Guid teamId, CancellationToken cancellationToken);
    Task<Team?> GetByNameAsync(string name, CancellationToken cancellationToken);
    Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken);
}

