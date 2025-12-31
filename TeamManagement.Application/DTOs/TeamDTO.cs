namespace Application.DTOs
{

    public sealed class TeamDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = default!;
        public Guid OwnerId { get; init; }
        public Guid? LeaderId { get; init; }
        public TeamStatus Status { get; init; }
        public IReadOnlyCollection<Guid> MemberIds { get; init; } = [];
        public DateTime CreatedAt { get; init; }
    }


}



