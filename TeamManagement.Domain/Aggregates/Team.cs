using TeamManagement.Core.Enum;
using TeamManagement.Domain.Common;
using TeamManagement.Domain.Entities;
using TeamManagement.Domain.Exceptions;
using TeamManagement.Domain.ValueObjects;

namespace TeamManagement.Domain.Aggregates;

public class Team : AggregateRoot
{
    private readonly List<TeamMember> _members = new();

    public TeamId Id { get; private set; }
    public string Name { get; private set; }
    public TeamStatus Status { get; private set; }
    public IReadOnlyCollection<TeamMember> Members => _members.AsReadOnly();
    public TeamLeader Leader { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }

    protected Team()
    {
    }

    public Team(TeamId id, string name)
    {
        Id = id;
        Name = name;
        Status = TeamStatus.Active;
        CreatedAt = DateTimeOffset.UtcNow;
    }

    public void AddMember(UserId userId)
    {
        ThrowIfArchived(nameof(AddMember));

        if (_members.Any(m => m.UserId == userId))
            throw new DuplicateTeamMemberException(nameof(userId));

        var member = new TeamMember(TeamMemberId.Create(Guid.NewGuid()), userId, DateTimeOffset.UtcNow);
        _members.Add(member);
    }

    public void RemoveMember(UserId userId)
    {
        ThrowIfArchived(nameof(RemoveMember));

        var member = _members.FirstOrDefault(m => m.UserId == userId);
        if (member is null)
            throw new MemberNotFoundException(nameof(userId));

        if (Leader?.Id == userId)
            Leader = null;

        _members.Remove(member);
    }

    public void AssignLeader(UserId userId)
    {
        ThrowIfArchived(nameof(AssignLeader));
        
        var member = _members.FirstOrDefault(m => m.UserId == userId);
        if (member is null)
            throw new LeaderMustBeMemberException(nameof(userId));

        if (Leader is not null)
            throw new OnlyOneLeaderAllowedException();

        Leader = TeamLeader.Create(userId);
    }
    
    public void Archive() => Status =  TeamStatus.Archived;
    
    public void Activate()  => Status = TeamStatus.Active;

    public bool IsArchived => Status == TeamStatus.Archived;

    private void ThrowIfArchived(string action)
    {
        if (IsArchived)
            throw new TeamArchivedException(action);
    }
}