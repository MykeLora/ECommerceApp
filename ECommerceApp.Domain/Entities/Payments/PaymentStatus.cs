using System.Text.Json.Serialization;

namespace E_commerce.Domain.Entities.Payments
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PaymentStatus
    {
        Pending,
        Completed,
        Failed,
        Refunded
    }
}

