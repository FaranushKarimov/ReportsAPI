using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Marketplace
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TypeMarket { get; set; }
        public string ClientId { get; set; }
        public string ApiKey { get; set; }
        public ICollection<Stock> Stocks { get; set; }
    }
}
