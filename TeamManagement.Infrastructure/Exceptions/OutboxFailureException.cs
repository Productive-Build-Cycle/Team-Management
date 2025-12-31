namespace TeamManagement.Infrastructure.Exceptions;

public class OutboxFailureException : InfrastructureException
{
    protected OutboxFailureException(string message = "") : base($"Outbox operation failed. {message}")
    {
    }
}