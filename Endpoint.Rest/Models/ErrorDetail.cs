using System.Text.Json;

namespace Endpoint.Rest.Models
{
    public record ErrorDetail(int statusCode, string message)
    {
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
