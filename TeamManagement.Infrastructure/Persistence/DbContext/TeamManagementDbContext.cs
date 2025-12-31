using Microsoft.EntityFrameworkCore;
using TeamManagement.Domain.Aggregates;
using TeamManagement.Domain.Entities;
using TeamManagement.Infrastructure.Persistence.Configurations;

namespace TeamManagement.Infrastructure.Persistence.DbContext;

public class TeamManagementDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public TeamManagementDbContext(DbContextOptions<TeamManagementDbContext> options) : base(options)
    {
    }

    public DbSet<Team> Teams => Set<Team>();
    public DbSet<TeamMember> TeamMembers => Set<TeamMember>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("tm");
        
        modelBuilder.ApplyConfiguration(new TeamConfiguration());
        modelBuilder.ApplyConfiguration(new TeamMemberConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}