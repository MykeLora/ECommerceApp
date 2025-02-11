using System.Text.Json.Serialization;

namespace E_commerce.Domain.Entities.Orders
{
    // Enum to represent the status of an order
    // The JsonStringEnumConverter ensures that enums are serialized as their string names
    // instead of integer values, enhancing readability.
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrderStatus
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Canceled
    }
}
