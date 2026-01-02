namespace TeamManagement.Infrastructure.Exceptions;

public class OutboxFailureException : InfrastructureException
{
    protected OutboxFailureException(string message) : base(message)
    {
    }

    protected OutboxFailureException(string message, Exception innerException) : base(message, innerException)
    {
    }
}