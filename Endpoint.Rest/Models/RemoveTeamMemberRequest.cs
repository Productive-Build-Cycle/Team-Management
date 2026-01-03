using System.ComponentModel.DataAnnotations;

using TeamManagement.Domain.ValueObjects;

namespace Endpoint.Rest.Models
{
    public class RemoveTeamMemberRequest
    {
        [Required]
        public required UserId UserId { get; set; }
    }
}
