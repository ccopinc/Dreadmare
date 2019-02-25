using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dreadmare.DTOModels;

namespace Dreadmare.Managers
{
    public class SiteManager
    {
        dm_dbEntities db = new dm_dbEntities();
        public Quotes GetQuote()
        {
            List<quote_Quote> list = db.quote_Quote.ToList();
            int n = list.Count;
            Random rnd = new Random();
            int i = rnd.Next(0, n);
            quote_Quote dbQuote = list[i];

            Quotes quote = new Quotes()
            {
                Quote =  dbQuote.Quote,
                QuoteBy = dbQuote.QuoteBy,
                QuoteByImage = dbQuote.QuoteByImage
            };

            return quote;
        }

    }
}