using Xunit;
using FluentAssertions;
using TeamManagement.Domain.Aggregates;
using TeamManagement.Domain.Exceptions;
using TeamManagement.Domain.ValueObjects;

namespace TeamManagement.Test.Domain;

public class TeamTest
{
    [Fact]
    public void CreateTeam_WithEmptyName_ShouldFail()
    {
        TeamId teamId = TeamId.Create(Guid.NewGuid());

        Action act = () => new Team(teamId, "");

        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void AddMember_WhenMemberNotExist_ShouldAddSuccessfully()
    {
        var teamId = TeamId.Create(Guid.NewGuid());
        var frontTeam = new Team(teamId, "FrontEnd Team");

        var userId = UserId.Create(Guid.NewGuid());

        frontTeam.AddMember(userId);

        frontTeam.Members.Should().ContainSingle(m => m.UserId.Value == userId.Value);
    }

    [Fact]
    public void RemoveMember_WhenMemberDoesNotExist_ShouldFail()
    {
        var teamId = TeamId.Create(Guid.NewGuid());
        var frontTeam = new Team(teamId, "FrontEnd Team");


        Action act = () => frontTeam.RemoveMember(UserId.Create(Guid.NewGuid()));

        act.Should().Throw<MemberNotFoundException>();
    }

    [Fact]
    public void ArchiveTeam_WhenAlreadyArchived_ShouldFail()
    {
        var teamId = TeamId.Create(Guid.NewGuid());
        var frontTeam = new Team(teamId, "FrontEnd Team");
        frontTeam.Archive();

        Action act = () => frontTeam.Archive();

        act.Should().Throw<TeamArchivedException>();
    }

    [Fact]
    public void Team_ShouldNeverHaveMoreThanOneLeader()
    {
        var teamId = TeamId.Create(Guid.NewGuid());
        var frontTeam = new Team(teamId, "FrontEnd Team");

        var userIdLeader = UserId.Create(Guid.NewGuid());
        var userIdMember = UserId.Create(Guid.NewGuid());

        frontTeam.AddMember(userIdLeader);
        frontTeam.AddMember(userIdMember);
        frontTeam.AssignLeader(userIdLeader);

        Action act = () => frontTeam.AssignLeader(userIdMember);

        act.Should().Throw<OnlyOneLeaderAllowedException>();
    }
}