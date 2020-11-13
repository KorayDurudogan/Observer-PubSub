using System.Text.Json.Serialization;

namespace SubscriberProject
{
    public class SubscribeRequest
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("device")]
        public string Device { get; set; }
    }
}
