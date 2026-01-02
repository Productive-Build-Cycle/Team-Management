using TeamManagement.Application.Abstraction.CQRS;
using TeamManagement.Core.Enum;

namespace TeamManagement.Application.Commands.ChangeTeamStatus
{
    public sealed record ChangeTeamStatusCommand
    (
        Guid TeamId,
        TeamStatus NewStatus
    ) : ICommand;
}