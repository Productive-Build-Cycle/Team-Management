namespace TeamManagement.Domain.Exceptions;

public class LeaderMustBeMemberException : DomainException
{
    public LeaderMustBeMemberException(string userId) :
        base($"User '{userId}' must be a team member before being assigned as leader.")
    {
    }
}