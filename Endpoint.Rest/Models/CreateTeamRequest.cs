using System.ComponentModel.DataAnnotations;

namespace Endpoint.Rest.Models
{
    public class CreateTeamRequest
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public required string Name { get; set; }
    }
}
