using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Prism
{
    class Program
    {
        // Update to local path to see the output.
        const string path = @"C:\Users\rzj\Desktop\card.txt";
        static void Main(string[] args)
        {

            Deck deck = new Deck();
            deck.Cards = deck.Shuffle();
            Hand hand = new Hand(deck);

            // hand the cards out to each player, sort and write contents to a file.
            HandCardsSortAndWriteToFile(hand);

        }

        private static void HandCardsSortAndWriteToFile(Hand hand)
        {
            StringBuilder p1 = new StringBuilder("Player #1:");
            StringBuilder p2 = new StringBuilder("Player #2:");
            StringBuilder p3 = new StringBuilder("Player #3:");
            StringBuilder p4 = new StringBuilder("Player #4:");
            StringBuilder p5 = new StringBuilder("Player #5:");

            List<Card> lstplayer1 = new List<Card>();
            List<Card> lstplayer2 = new List<Card>();
            List<Card> lstplayer3 = new List<Card>();
            List<Card> lstplayer4 = new List<Card>();
            List<Card> lstplayer5 = new List<Card>();

            for (int p = 0; p < 5; p++)
            {
                for (int i = 1; i <= 5; i++)
                {
                    Card card = hand.DealRandomCard();
                    switch (i)
                    {
                        case 1: lstplayer1.Add(card); break;
                        case 2: lstplayer2.Add(card); break;
                        case 3: lstplayer3.Add(card); break;
                        case 4: lstplayer4.Add(card); break;
                        case 5: lstplayer5.Add(card); break;
                        default:
                            break;
                    }
                }
            }

            foreach (var item in lstplayer1.OrderBy(x => x.Value))
            {
                p1.Append(GetValue(item.Value) + item.Suit + "-");
            }

            foreach (var item in lstplayer2.OrderBy(x => x.Value))
            {
                p2.Append(GetValue(item.Value) + item.Suit + "-");
            }

            foreach (var item in lstplayer3.OrderBy(x => x.Value))
            {
                p3.Append(GetValue(item.Value) + item.Suit + "-");
            }

            foreach (var item in lstplayer4.OrderBy(x => x.Value))
            {
                p4.Append(GetValue(item.Value) + item.Suit + "-");
            }

            foreach (var item in lstplayer5.OrderBy(x => x.Value))
            {
                p5.Append(GetValue(item.Value) + item.Suit + "-");
            }


            File.WriteAllText(path, string.Empty); // clear file contents before writing to it

            // Append contents
            using (StreamWriter file = new System.IO.StreamWriter(path, true))
            {
                file.WriteLine(p1.ToString().TrimEnd('-'));
                file.WriteLine(p2.ToString().TrimEnd('-'));
                file.WriteLine(p3.ToString().TrimEnd('-'));
                file.WriteLine(p4.ToString().TrimEnd('-'));
                file.WriteLine(p5.ToString().TrimEnd('-'));
            }
        }

        private static string GetValue(int item)
        {
            string value = string.Empty;
            switch (item)
            {
                case 11:
                    value = "J";
                    break;
                case 12:
                    value = "Q";
                    break;
                case 13:
                    value = "K";
                    break;
                case 14:
                    value = "A";
                    break;
                default:
                    value = item.ToString();
                    break;
            }
            return value;
        }

    }
}
