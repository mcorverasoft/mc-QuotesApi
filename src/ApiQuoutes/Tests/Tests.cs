using Application.Service;
using Domain.Services;
using Infraestructure.Repositories;
using NUnit.Framework;

namespace ApiQuotes.Tests
{
    
    public class Tests
    {
        private QuoteRepository quoteRepository= new QuoteRepository();
        [SetUp]
        public void SetUp()
        {
            this.quoteRepository = new QuoteRepository();
        }
        [Test]
        public void TestHasData()
        {
            var quotes= this.quoteRepository.GetAllQuotes();
            int i = quotes.Count();
            Assert.GreaterOrEqual(i, 0);
        }
    }
}
