using Domain.Models;
using Infraestructure.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infraestructure.ApiClients
{
    public class QuoteApiClient
    {
        private readonly String urlApiQuotes;
        public QuoteApiClient()
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            this.urlApiQuotes = configuration["UrlApiQuotes"];
        }

        public async Task<IEnumerable<QuoteModel>> GetQuotes()
        {

            IEnumerable<QuoteModel>? quotes = new List<QuoteModel>();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(this.urlApiQuotes);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                if(responseBody!=null)
                    quotes = JsonSerializer.Deserialize<IEnumerable<QuoteModel>>(responseBody);

            }
            else
                Console.WriteLine("La solicitud no fue exitosa. Código de estado: " + response.StatusCode);

            return (quotes == null) ? Enumerable.Empty<QuoteModel>() : quotes;

        }
    }
}
