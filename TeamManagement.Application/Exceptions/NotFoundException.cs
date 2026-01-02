namespace TeamManagement.Application.Exceptions;

public sealed class NotFoundException : Exception
{
    public NotFoundException(string message="") : base($"Team Not Found Exception. {message}") {}
}