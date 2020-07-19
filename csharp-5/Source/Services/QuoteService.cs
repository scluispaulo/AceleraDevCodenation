using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class QuoteService : IQuoteService
    {
        private ScriptsContext _context;
        private IRandomService _randomService;

        public QuoteService(ScriptsContext context, IRandomService randomService)
        {
            this._context = context;
            this._randomService = randomService;
        }

        public Quote GetAnyQuote()
        {
            int quotesMax = _context.Quotes.Count();
            int rand = _randomService.RandomInteger(quotesMax);
            return _context.Quotes.ToList().ElementAt(rand);
        }

        public Quote GetAnyQuote(string actor)
        {
            var actorQuotes = _context.Quotes.Where(x => x.Actor.Equals(actor)).ToList();
            int quotesMax = actorQuotes.Count();
            if(quotesMax < 1)
                return null;
            int rand = _randomService.RandomInteger(quotesMax);
            return actorQuotes.ElementAt(rand);
        }
    }
}