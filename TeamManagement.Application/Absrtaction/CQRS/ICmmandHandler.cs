using System;
using Application.Abstractions.CQRS;


public interface ICommandHandler<in TCommand> where TCommand :ICommand

{
    Task HandleAsync(TCommand command, CancellationToken cancellationToken);
}



