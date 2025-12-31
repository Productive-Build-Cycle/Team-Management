namespace TeamManagement.Infrastructure.Exceptions;

public class UnexpectedInfrastructureException : InfrastructureException
{
    public UnexpectedInfrastructureException(string message = "") : base(
        $"An unexpected infrastructure error occurred. {message}")
    {
    }
}