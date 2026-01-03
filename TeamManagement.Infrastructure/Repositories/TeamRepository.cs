using Microsoft.EntityFrameworkCore;
using TeamManagement.Application.Abstraction;
using TeamManagement.Domain.Aggregates;
using TeamManagement.Infrastructure.Exceptions;
using TeamManagement.Infrastructure.Persistence.DbContext;

namespace TeamManagement.Infrastructure.Repositories;

public sealed class TeamRepository : ITeamRepository
{
    private readonly TeamManagementDbContext _dbContext;

    public TeamRepository(TeamManagementDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task AddAsync(Team team, CancellationToken cancellationToken)
    {
        try
        {
            await _dbContext.Teams.AddAsync(team, cancellationToken);
        }
        catch (DbUpdateException ex)
        {
            throw new DatabaseConnectionException("Failed to add Team entity to database.", ex);
        }
        catch (Exception ex)
        {
            throw new UnexpectedInfrastructureException("Unexpected error while adding Team.", ex);
        }
    }

    public async Task<Team?> GetByIdAsync(Guid teamId, CancellationToken cancellationToken)
    {
        try
        {
            return await _dbContext.Teams
                .Include(t => t.Members)
                .FirstOrDefaultAsync(t => t.Id.Value == teamId, cancellationToken);
        }
        catch (Exception ex)
        {
            throw new UnexpectedInfrastructureException("Unexpected error while loading Team by id.", ex);
        }
    }

    public async Task<Team?> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        try
        {
            return await _dbContext.Teams
                .Include(t => t.Members)
                .FirstOrDefaultAsync(t => t.Name == name, cancellationToken);
        }
        catch (Exception ex)
        {
            throw new UnexpectedInfrastructureException("Unexpected error while loading Team by name.", ex);
        }
    }

    public async Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken)
    {
        try
        {
            return await _dbContext.Teams.AnyAsync(t => t.Name == name, cancellationToken);
        }
        catch (Exception ex)
        {
            throw new UnexpectedInfrastructureException("Unexpected error while checking Team existence by name.", ex);
        }
    }

    public async Task SaveChangeAsync(CancellationToken cancellationToken)
    {
        try
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException ex)
        {
            throw new DatabaseConnectionException("Failed to persist changes to database.", ex);
        }
        catch (Exception ex)
        {
            throw new UnexpectedInfrastructureException("Unexpected error while saving changes.", ex);
        }
    }
}