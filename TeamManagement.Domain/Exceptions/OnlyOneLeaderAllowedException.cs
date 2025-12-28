namespace TeamManagement.Domain.Exceptions;

public class OnlyOneLeaderAllowedException : DomainException
{
    public OnlyOneLeaderAllowedException() : base("This team already has a leader. Only one leader is allowed.")
    {
    }
}