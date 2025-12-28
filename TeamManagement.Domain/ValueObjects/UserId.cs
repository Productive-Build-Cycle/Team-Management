namespace TeamManagement.Domain.ValueObjects;

public record UserId
{
    public Guid Value { get; }

    private UserId(Guid value)
    {
        Value = value;
    }

    public static UserId Create(Guid value)
    {
        if(value == Guid.Empty)
            throw new ArgumentException("Value cannot be empty");

        return new UserId(value);
    }
    
    public override string ToString() => Value.ToString();
}