namespace TeamManagement.Domain.Exceptions;

public class DuplicateTeamMemberException : DomainException
{
    public DuplicateTeamMemberException(string userId) :
        base($"Member with UserId '{userId}' already exists in this team.")
    {
    }
}