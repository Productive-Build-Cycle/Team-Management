namespace TeamManagement.Infrastructure.Exceptions;

public class DatabaseConnectionException : InfrastructureException
{
    public DatabaseConnectionException(string message = "") : base($"Cannot connect to database. {message}")
    {
    }
}
