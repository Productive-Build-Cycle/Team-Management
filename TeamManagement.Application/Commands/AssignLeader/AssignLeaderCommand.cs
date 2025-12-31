using System;
using Application.Abstrations.CQRS;

namespace Application.Command.AssignLeader
{
    public sealed record AssignLeaderCommand
    (
    Guid TeamId,
    Guid LeadrId

    ) : ICommand;


}

