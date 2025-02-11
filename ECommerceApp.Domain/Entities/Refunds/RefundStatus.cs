using System.Text.Json.Serialization;
namespace ECommerceApp.Models
{
    // Enum to represent the status of a refund
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RefundStatus
    {
        Pending,
        Completed,
        Failed
    }
}
