using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IQuoteService
    {
        void SaveQuotes();
        Task<IEnumerable<QuoteDTO>> GetAllQuotes();
        Task<IEnumerable<QuoteDTO>> GetQuotesMoreThanTenWords(int limit);
        Task<IEnumerable<QuoteDTO>> GetQuotesLessThanTenWords(int limit);
        
    }
}
