using TeamManagement.Domain.ValueObjects;

namespace TeamManagement.Domain.Entities;

public class TeamMember
{
    public TeamMemberId Id { get; private set; }
    public UserId UserId { get; private set; }
    public DateTimeOffset JoinedAt { get; private set; }

    private TeamMember()
    {
    }

    public TeamMember(TeamMemberId id, UserId userId, DateTimeOffset joinedAt)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
        UserId = userId ?? throw new ArgumentNullException(nameof(userId));
        JoinedAt = joinedAt;
    }

    public override string ToString() => $"{UserId.Value} joined at {JoinedAt:O}";
}