
namespace Application.commands.ChangeTeamStatus
{
    public sealed record ChangeTeamStatusCommand
    (
        Guid TeamId,
        bool IsActive,
        ChangeTeamStatus NewStatus
    ) : ICommand;
}