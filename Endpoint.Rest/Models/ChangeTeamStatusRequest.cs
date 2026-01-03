using System.ComponentModel.DataAnnotations;

using TeamManagement.Core.Enum;

namespace Endpoint.Rest.Models
{
    public class ChangeTeamStatusRequest 
    {
        [Required]
        public TeamStatus NewStatus { get; set; }
    }
}
