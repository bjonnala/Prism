using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism
{
    class Deck : Card
    {
        public List<Card> Cards = new List<Card>();

        public Deck()
        {
            // Hydrate the Deck object
            List<Card> heart = GenerateCards("H"); // hearts
            List<Card> diamond = GenerateCards("D"); // diamonds
            List<Card> spade = GenerateCards("S"); // spade
            List<Card> club = GenerateCards("C"); // club

            // concat all the lists to form a final list of cards
            Cards = heart.Concat(diamond).Concat(spade).Concat(club).ToList();
        }

        public List<Card> Shuffle()
        {
            int count = Cards.Count;
            while (count > 1)
            {
                Random rand = new Random();
                int i = rand.Next(count--);
                Card temp = Cards[count];
                Cards[count] = Cards[i];
                Cards[i] = temp;
            }
            return Cards;
        }

        private List<Card> GenerateCards(string suit)
        {
            List<Card> cards = new List<Card>();

            for (int h = 2; h <= 14; h++)
            {
                Card card = new Card
                {
                    Suit = suit,
                    Value = h
                };
                cards.Add(card);
            }
            return cards;
        }
    }
}
