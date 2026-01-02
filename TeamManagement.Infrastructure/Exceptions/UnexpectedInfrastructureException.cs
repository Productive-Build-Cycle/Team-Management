namespace TeamManagement.Infrastructure.Exceptions;

public class UnexpectedInfrastructureException : InfrastructureException
{
    public UnexpectedInfrastructureException(string message) : base(message)
    {
    }
    public UnexpectedInfrastructureException(string message, Exception innerException) : base(message, innerException)
    {
    }
}