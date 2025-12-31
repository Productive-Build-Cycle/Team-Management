namespace Application.Exceptions;

public sealed class TeamNameAlreadyExistsException : Exception
{
    public TeamNameAlreadyExistsException(string teamName)
        : base($"A team with name '{teamName}' already exists.")
    {
    }
}
