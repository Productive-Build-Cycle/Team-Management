using TeamManagement.Application.Abstraction.CQRS;
using TeamManagement.Domain.ValueObjects;

namespace TeamManagement.Application.Commands.AddMember;

public sealed record AddMemberCommand(
    Guid TeamId,
    UserId UserId
) : ICommand;