using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaraffaServerConsole
{
    class TeamDeck
    {
        List<Card> pointDeck;

        public TeamDeck()
        {
            pointDeck = new List<Card>();
        }

        //Metodo per aggiunta della mano raccolta al mazzo dei punti
        public void AddCard(List<Card> take)
        {
            pointDeck.Add(take[0]);
            pointDeck.Add(take[1]);
            pointDeck.Add(take[2]);
            pointDeck.Add(take[3]);
        }

        //Metodo per calcolo del punteggio
        public int CalcScore(bool last)
        {
            int figures = 0;    //Variabile per conteggio figure

            foreach(Card c in pointDeck)
            {
                if (c.Value == Value.Asso)
                    figures += 3;
                else if (c.Value == Value.Fante || c.Value == Value.Cavallo || c.Value == Value.Re || c.Value == Value.Due || c.Value == Value.Tre)
                    figures++;
            }

            if (!last)
                return figures / 3;
            else
                return (figures / 3) + 1;
        }
    }
}
