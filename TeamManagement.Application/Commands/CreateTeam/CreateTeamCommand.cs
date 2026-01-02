using TeamManagement.Application.Abstraction.CQRS;

namespace TeamManagement.Application.Commands.CreateTeam

{
    public sealed record CreateTeamCommand(
    string Name
) : ICommand;

}

