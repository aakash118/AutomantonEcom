using System.Text.Json.Serialization;


namespace BuildingBlocks.Exceptions
{
    public class ExceptionDetails
    {
        public string? Detail { get; set; }
        public string? Title { get; set; }
        public int StatusCode { get; set; }
        public string? Instance { get; set; }
        [JsonExtensionData]
        public IDictionary<string, object>? Extensions { get; set; } = new Dictionary<string, object>();
    }
}
