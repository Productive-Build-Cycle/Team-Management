namespace TeamManagement.Infrastructure.Exceptions;

public class DatabaseConnectionException : InfrastructureException
{
    public DatabaseConnectionException(string message) : base(message)
    {
    }

    public DatabaseConnectionException(string message, Exception innerException) : base(message, innerException)
    {
    }
}