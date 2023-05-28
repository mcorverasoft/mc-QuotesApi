using Domain.Models;
using Infraestructure.Entities;
using Infraestructure.IRepository;
using System.Text.Json;
using Microsoft.Extensions.Configuration;


namespace Infraestructure.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly string PathData;
        private readonly string FileJson;
        public QuoteRepository()
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            this.PathData = configuration["Path"];
            this.FileJson = configuration["File"];

            if (!Directory.Exists(this.PathData))
                Directory.CreateDirectory(this.PathData);
            
        }
        public IEnumerable<QuoteModel> GetAllQuotes()
        {
            var json = File.ReadAllText(Path.Combine(this.PathData, this.FileJson));
            var quotes= JsonSerializer.Deserialize<IEnumerable<QuoteModel>>(json);
            
            return (quotes == null)? Enumerable.Empty<QuoteModel>():quotes;
        }

        public void SaveQuotes(IEnumerable<QuoteModel> quotes)
        {
            var json = JsonSerializer.Serialize(quotes);
            File.WriteAllText(Path.Combine(this.PathData, this.FileJson), json);
        }
    }
}