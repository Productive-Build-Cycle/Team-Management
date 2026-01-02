using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamManagement.Domain.Aggregates;
using TeamManagement.Domain.ValueObjects;

namespace TeamManagement.Infrastructure.Persistence.Configurations;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.ToTable("Teams");
        
        builder.HasKey(x => x.Id);

        builder.Property(t => t.Id).HasConversion(id => id.Value, value => TeamId.Create(value));

        builder.Property(t => t.Name).IsRequired().HasMaxLength(100);

        builder.Property(t => t.CreatedAt).IsRequired();

        builder.Property(t => t.Status).IsRequired().HasConversion<string>();

        builder.OwnsOne(t => t.Leader,
            leader =>
            {
                leader.Property(l => l.Id).HasConversion(id => id.Value, value => UserId.Create(value))
                    .HasColumnName("LeaderUserId");
                leader.Property(l => l.AssignedAt).HasColumnName("LeaderAssignedAt");
            });

        builder.HasMany(t => t.Members).WithOne().HasForeignKey("TeamId").OnDelete(DeleteBehavior.Cascade);
    }
}