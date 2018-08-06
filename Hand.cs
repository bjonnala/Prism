using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism
{
    class Hand
    {
        private readonly Deck _deck;
        public Hand(Deck deck)
        {
            _deck = deck;
        }
        public Card DealRandomCard()
        {
            // shuffle and return a random card from the deck for each player
            Random rand = new Random();
            var list = _deck.Shuffle();
            if (list != null && list.Count() > 0)
            {
                int r = rand.Next(list.Count());
                return _deck.Cards.ElementAt(r);
            }
            return _deck.Cards.FirstOrDefault();
        }
    }
}
