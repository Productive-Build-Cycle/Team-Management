using System;
using System.Collections.Generic;
using System.Text;

using TeamManagement.Application.Abstraction;
using TeamManagement.Application.Abstraction.CQRS;
using TeamManagement.Application.Commands.AddMember;
using TeamManagement.Application.Commands.AssignLeader;
using TeamManagement.Application.Commands.ChangeTeamStatus;
using TeamManagement.Application.Commands.CreateTeam;
using TeamManagement.Application.Commands.RemoveMember;
using TeamManagement.Core.Enum;
using TeamManagement.Domain.ValueObjects;

namespace TeamManagement.Application.Facade
{
    public class TeamFacade : ITeamFacade
    {
        private readonly ICommandHandler<CreateTeamCommand> _create;
        private readonly ICommandHandler<AddMemberCommand> _addMember;
        private readonly ICommandHandler<RemoveMemberCommand> _removeMember;
        private readonly ICommandHandler<AssignLeaderCommand> _assignLeader;
        private readonly ICommandHandler<ChangeTeamStatusCommand> _changeStatus;

        public TeamFacade(
            ICommandHandler<CreateTeamCommand> create,
            ICommandHandler<AddMemberCommand> addMember,
            ICommandHandler<RemoveMemberCommand> removeMember,
            ICommandHandler<AssignLeaderCommand> assignLeader,
            ICommandHandler<ChangeTeamStatusCommand> changeStatus)
        {
            _create = create;
            _addMember = addMember;
            _removeMember = removeMember;
            _assignLeader = assignLeader;
            _changeStatus = changeStatus;
        }
        public Task AddMemberAsync(AddMemberCommand command, CancellationToken cancellation) 
            => _addMember.HandleAsync(command, cancellation);
        public Task AssignLeaderAsync(AssignLeaderCommand command, CancellationToken cancellationToken)
            => _assignLeader.HandleAsync(command, cancellationToken);

        public Task ChangeStatusAsync(ChangeTeamStatusCommand command, CancellationToken cancellationToken)
            => _changeStatus.HandleAsync(command, cancellationToken);

        public Task CreateTeamAsync(CreateTeamCommand command, CancellationToken cancellationToken)
            => _create.HandleAsync(command, cancellationToken);

        public Task RemoveMemberAsync(RemoveMemberCommand command, CancellationToken cancellationToken)
            => _removeMember.HandleAsync(command, cancellationToken);
    }
}
