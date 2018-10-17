using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaraffaClient
{
    // classe helper per l'ordinamento della mano per seme
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
        // collezioni globali
        List<Card> hand;

        // proprietà che indica la presenza del seme dominante nella mano
        public bool Vseed { get; set; }

        // costruttore
        public Hand(List<Card> hnd)
        {
            this.hand = hnd;
            hand.Sort(new SortBySeed());
            Vseed = false;
        }

        // metodo che popola una lista con le carte giocabili
        public void ValidCards(Seed s)
        {
            foreach (Card c in hand)
            {
                if (c != null)
                {
                    if (c.CardSeed == s)
                    {
                        Vseed = true;
                        return;
                    }
                }
            }

            Vseed = false;
        }

        // indicizzatore per prelevare le carte dalla lista
        public Card this[int pos]
        {
            get
            {
                return hand[pos];
            }

            set
            {
                hand[pos] = value;
            }
        }
    }
}
