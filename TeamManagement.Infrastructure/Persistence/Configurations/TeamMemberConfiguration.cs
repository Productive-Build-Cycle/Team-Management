using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamManagement.Domain.Entities;
using TeamManagement.Domain.ValueObjects;

namespace TeamManagement.Infrastructure.Persistence.Configurations;

public class TeamMemberConfiguration : IEntityTypeConfiguration<TeamMember>
{
    public void Configure(EntityTypeBuilder<TeamMember> builder)
    {
        builder.ToTable("TeamMembers");
        
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id).HasConversion(id => id.Value, value => TeamMemberId.Create(value));

        builder.Property(t => t.UserId).HasConversion(id => id.Value, value => UserId.Create(value)).IsRequired();

        builder.Property(t => t.JoinedAt).IsRequired();
    }
}