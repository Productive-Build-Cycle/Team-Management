using System;
using System.Collections.Generic;
using System.Text;

using TeamManagement.Application.Commands.AddMember;
using TeamManagement.Application.Commands.AssignLeader;
using TeamManagement.Application.Commands.ChangeTeamStatus;
using TeamManagement.Application.Commands.CreateTeam;
using TeamManagement.Application.Commands.RemoveMember;
using TeamManagement.Core.Enum;
using TeamManagement.Domain.ValueObjects;

namespace TeamManagement.Application.Abstraction
{
    public interface ITeamFacade
    {
        Task CreateTeamAsync(CreateTeamCommand command, CancellationToken cancellationToken);
        Task AddMemberAsync(AddMemberCommand command, CancellationToken cancellationToken);
        Task RemoveMemberAsync(RemoveMemberCommand command, CancellationToken cancellationToken);
        Task AssignLeaderAsync(AssignLeaderCommand command, CancellationToken cancellationToken);
        Task ChangeStatusAsync(ChangeTeamStatusCommand command, CancellationToken cancellationToken);
    }
}
