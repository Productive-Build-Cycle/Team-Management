namespace TeamManagement.Domain.ValueObjects;

public record TeamMemberId
{
    public Guid Value { get; }

    private TeamMemberId(Guid value)
    {
        Value = value;
    }

    public static TeamMemberId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("TeamMemberId cannot be empty");

        return new TeamMemberId(value);
    }

    public override string ToString() => Value.ToString();
}