using System.ComponentModel.DataAnnotations;

using TeamManagement.Domain.ValueObjects;

namespace Endpoint.Rest.Models
{
    public class AssignTeamLeaderRequest
    {
        [Required]
        public required UserId MemberId { get; set; }
    }
}
