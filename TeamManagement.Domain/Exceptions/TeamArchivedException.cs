namespace TeamManagement.Domain.Exceptions;

public class TeamArchivedException : DomainException
{
    public TeamArchivedException(string action) : base($"Cannot perform '{action}' because the team is archived.")
    {
    }
}