using Domain.Models;

namespace ApiQuoutes.DTO
{
    public class QuoteResponse
    {
        public IEnumerable<QuoteDTO>? Quotes { get; set; }
        public int TotalElements { get; set; }
    }
}
