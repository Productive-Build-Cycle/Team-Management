using TeamManagement.Application.Abstraction.CQRS;
using TeamManagement.Domain.ValueObjects;

namespace TeamManagement.Application.Commands.AssignLeader
{
    public sealed record AssignLeaderCommand
    (
    Guid TeamId,
    UserId UserId

    ) : ICommand;


}

