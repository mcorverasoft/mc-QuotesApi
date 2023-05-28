using Domain.Models;
using Domain.Services;
using Infraestructure.ApiClients;
using Infraestructure.IRepository;


namespace Application.Service
{
    public class QuoteService : IQuoteService
    {
        private readonly IQuoteRepository QuoteRepository;
        private readonly QuoteApiClient QuoteApliClient;

        public QuoteService(IQuoteRepository _QuoteRepository) { 
            QuoteRepository = _QuoteRepository;
            QuoteApliClient=new QuoteApiClient();
        }

        public async Task<IEnumerable<QuoteDTO>> GetAllQuotes() {
            //First get All Quotes from QuoteApliClient
            var quotes=await QuoteApliClient.GetQuotes();
            //Transform List<QuotesModel> to List<QuotesDTO>, Without use Automapper:
            var quotesDTO = quotes.Select(quote => new QuoteDTO()
            {
                Id = quote.Id,
                Quote = quote.Quote,
                Autor = quote.Author,
                HtmlQuote = quote.HthmlQuote
            });
            return quotesDTO;
        }

        public async void SaveQuotes()
        {
            QuoteRepository.SaveQuotes(await QuoteApliClient.GetQuotes());
        }

        public async Task<IEnumerable<QuoteDTO>> GetQuotesMoreThanTenWords(int limit)
        {
            //First get All Quotes from QuoteApliClient
            var quotes = await QuoteApliClient.GetQuotes();
            //Get Quotes that has more than 10 words
            //and Transform List<QuotesModel> to List<QuotesDTO>,
            //Without use Automapper:
            var quotesFiltered = quotes.Where(q => q.Quote.Split(" ").Length >= 10)
                .OrderByDescending(q=>q.Quote.Length)
                .Take(limit<=0?int.MaxValue:limit)
                .Select(quote => new QuoteDTO()
                {
                    Id = quote.Id,
                    Quote = quote.Quote,
                    Autor = quote.Author,
                    HtmlQuote = quote.HthmlQuote
                })
                ;
            return quotesFiltered;
        }
        public async Task<IEnumerable<QuoteDTO>> GetQuotesLessThanTenWords(int limit)
        {
            //First get All Quotes from QuoteApliClient
            var quotes = await QuoteApliClient.GetQuotes();
            //Get Quotes that has more than 10 words
            //and Transform List<QuotesModel> to List<QuotesDTO>,
            //Without use Automapper:
            var quotesFiltered = quotes.Where(q => q.Quote.Split(" ").Length < 10)
                .OrderBy(q => q.Quote.Length)
                .Take(limit <=0 ? int.MaxValue : limit)
                .Select(quote => new QuoteDTO()
                {
                    Id = quote.Id,
                    Quote = quote.Quote,
                    Autor = quote.Author,
                    HtmlQuote = quote.HthmlQuote
                });
            return quotesFiltered;
        }
    }
}