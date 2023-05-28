using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class QuoteModel
    {
        [JsonPropertyName("c")]
        public String Id { get; set; } = "0";
        [JsonPropertyName("q")]
        public String Quote { get; set; } = "";
        [JsonPropertyName("h")]
        public String HthmlQuote { get; set; } = "";
        [JsonPropertyName("a")]
        public String Author { get; set; } = "";
    }
}