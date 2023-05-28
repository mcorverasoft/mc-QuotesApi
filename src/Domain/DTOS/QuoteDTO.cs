using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class QuoteDTO
    {
        public String? Id { get; set; }
        public String? Quote { get; set; }
        public String? HtmlQuote { get; set; }
        public String? Autor { get; set; }
    }
}