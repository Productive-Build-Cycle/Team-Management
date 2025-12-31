using Application.Abstractions.CQRS;

namespace Application.Commands.RemoveMember;




public sealed record RemoveMemberCommand(
    Guid TeamId,
    Guid MemberId
) : ICommand;
