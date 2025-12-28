namespace TeamManagement.Domain.Exceptions;

public class MemberNotFoundException : DomainException
{
    public MemberNotFoundException(string userId) : base($"Member with UserId '{userId}' was not found in this team.")
    {
    }
}