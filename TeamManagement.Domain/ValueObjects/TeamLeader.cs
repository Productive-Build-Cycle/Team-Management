namespace TeamManagement.Domain.ValueObjects;

public record TeamLeader
{
    public UserId Id { get; }
    public DateTimeOffset AssignedAt { get; }

    private TeamLeader(UserId id, DateTimeOffset assignedAt)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
        AssignedAt = assignedAt;
    }

    public static TeamLeader Create(UserId id)
    {
        if (id is null)
            throw new ArgumentNullException(nameof(id));

        return new TeamLeader(id, DateTimeOffset.UtcNow);
    }

    public override string ToString() => $"{Id.Value}, Assigned at: {AssignedAt:O}";
}