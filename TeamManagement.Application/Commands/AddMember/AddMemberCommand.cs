using system;
using Application.Abstractions.CQRS;

namespace Application.Commands.AddMember;
public sealed record AddMemberCommand(
    Guid TeamId,
    Guid MemberId,
    ) : ICommand;
    