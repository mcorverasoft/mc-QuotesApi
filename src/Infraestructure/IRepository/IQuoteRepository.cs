using Domain.Models;
using Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.IRepository
{
    public interface IQuoteRepository
    {
        public IEnumerable<QuoteModel> GetAllQuotes();
        public void SaveQuotes(IEnumerable<QuoteModel> quotes);
    }
}
