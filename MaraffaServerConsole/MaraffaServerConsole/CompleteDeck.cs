using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaraffaServerConsole
{
    class CompleteDeck
    {
        List<Card> deck;
        //Costruttore per inizializzare il mazzo
        public CompleteDeck()
        {
            deck = new List<Card>();

            for (Seed s = 0; (int)s < 4; s++)
                for (Value i = 0; (int)i < 10; i++)
                    deck.Add(new Card(i, s));

            //Corrisponde a:

            //for(int i = 0; i < 10; i++)
            //    deck.Add(new Card(i, Seed.Bastoni));

            //for (int i = 0; i < 10; i++)
            //    deck.Add(new Card(i, Seed.Coppe));

            //for (int i = 0; i < 10; i++)
            //    deck.Add(new Card(i, Seed.Denari));

            //for (int i = 0; i < 10; i++)
            //    deck.Add(new Card(i, Seed.Spade));
        }

        //Indicizzatore per prelevare le carte dal mazzo
        public Card this[int i]
        {
            get
            {
                return deck[i];
            }
        }
        
        //Metodo per taglio del mazzo
        /*
         *      1. viene generata casualmente la posizione in cui verrà tagliato il mazzo
         *      2. una nuova lista viene caricata con le carte presenti dalla cima del mazzo alla posizione appena generata
         *      3. le carte presenti dalla cima del mazzo alla posizione generata vengono rimosse dal mazzo originale
         *      4. le carte precedentemente rimosse vengono aggiunte in coda al mazzo originale
         */
        public void Cut()
        {
            Random rd = new Random(Environment.TickCount * DateTime.Now.Millisecond);
            int cutPosition = rd.Next(0, deck.Count);

            List<Card> d = deck.GetRange(0, cutPosition);
            deck.RemoveRange(0, cutPosition);
            deck.AddRange(d);
        }

        //Metodo per mischiare il mazzo
        /*
         * L'algoritmo prevede di prendere casualmente una carta dal mazzo fra quelle non ancora mischiate e scambiarla con l'ultima del mazzo
         * di quelle non ancora mescolate. Il procedimento si ripete per ogni carta del mazzo non ancora mescolato, fino a quando non rimane 
         * una sola carta. I passi sono:
         *      1. x assume il numero di carte presenti nel mazzo
         *      2. newPos prende come valore un numero che viene generato casualmente fra 0 ed x
         *      3. l'x-esima carta viene scambiata con la carta in posizione newPos
         *      4. i passi 2 e 3 si ripetono fino a quando rimarrà una sola carta non mescolata 
         */
        public void Mix()
        {
            Random rd = new Random(Environment.TickCount * DateTime.Now.Millisecond);       
            int newPos;
            Card aux;

            for (int x = deck.Count - 1; x > 1; x--)
            {
                // scelta della carta da spostare
                newPos = rd.Next(0, x);

                // scambio carte
                aux = deck[x];
                deck[x] = deck[newPos];
                deck[newPos] = aux;
            }
        }
    }
}
