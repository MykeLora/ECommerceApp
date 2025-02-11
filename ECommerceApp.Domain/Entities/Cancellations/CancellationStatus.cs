using System.Text.Json.Serialization;

namespace E_commerce.Domain.Entities.Status
{
    // Enum to represent the status of a cancellation request
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CancellationStatus
    {
        Pending,
        Approved,
        Rejected
    }
}
