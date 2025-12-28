using System;

namespace Application.Abstraction
{
    public interface ITeamRepository
    {
        task AddAsync(Team team, CancellationToken cancellationToken);
            Task<Team?> GetByIdAsync(Guid teamId, CancellationToken cancellationToken);
        Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken);
    }

}

