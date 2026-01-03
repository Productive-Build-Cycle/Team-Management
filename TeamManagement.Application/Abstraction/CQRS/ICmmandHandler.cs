using TeamManagement.Application.OperationResult;

namespace TeamManagement.Application.Abstraction.CQRS;

public interface ICommandHandler<in TCommand, TResultData> where TCommand : ICommand
{
    Task<Result<TResultData>> HandleAsync(TCommand command, CancellationToken cancellationToken);
}

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    Task HandleAsync(TCommand command, CancellationToken cancellationToken);
}