using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entities
{
    public class QuoteEntity
    {
        public String? Id { get; set; }
        public String? Quote { get; set; }
        public String? QuoteHTML { get; set; }
        public String? Author { get; set; }
    }
}
