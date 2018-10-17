using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaraffaServerConsole
{
    class SortBySeed : IComparer<Card>
    {
        public int Compare(Card c1, Card c2)
        {
            if (c1.CardSeed > c2.CardSeed)
                return 1;
            else if (c1.CardSeed < c2.CardSeed)
                return -1;
            else
                return 0;
        }
    }

    class Hand
    {
        List<Card> hand;

        public Hand(List<Card> hnd)
        {
            this.hand = hnd;
            hand.Sort(new SortBySeed());
        }

        public Hand()
        {
            hand = new List<Card>();
        }

        public void ValidCards(List<Card> validCard, Seed s)
        {
            foreach (Card c in hand)
                if (c.CardSeed == s)
                    validCard.Add(c);
        }

        public Card this[int i]
        {
            get
            {
                return hand[i];
            }

            set
            {
                hand[i] = value;

                hand.Sort(new SortBySeed());
            }
        }

        public List<Card> EntireHand
        {
            get
            {
                return hand;
            }
        }
    }
}
