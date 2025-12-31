using System;

namespace Appliactions.Abstractions.CQRS;

public interface ICommandHandler<in TCommand> where TCommand : ICommand

{
    Task HandleAsync(TCommand command, CancellationToken cancellationToken);
}



