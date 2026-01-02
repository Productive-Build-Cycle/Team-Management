using TeamManagement.Application.Abstraction.CQRS;
using TeamManagement.Domain.ValueObjects;

namespace TeamManagement.Application.Commands.RemoveMember;

public sealed record RemoveMemberCommand(
    Guid TeamId,
    UserId UserId
) : ICommand;
