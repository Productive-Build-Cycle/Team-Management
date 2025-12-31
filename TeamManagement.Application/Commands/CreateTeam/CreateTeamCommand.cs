using Application.Abstractions.CQRS;

namespace Application.Commands.CreateTeam

{
    public sealed record CreateTeamCommand(
    string Name
) : ICommand;

}

