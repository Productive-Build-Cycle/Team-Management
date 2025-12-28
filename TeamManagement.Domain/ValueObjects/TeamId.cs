namespace TeamManagement.Domain.ValueObjects;

public record TeamId
{
    public Guid Value { get; }

    private TeamId(Guid value)
    {
        Value = value;
    }

    public static TeamId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("TeamId cannot be empty");

        return new TeamId(value);
    }

    public override string ToString() => Value.ToString();
}