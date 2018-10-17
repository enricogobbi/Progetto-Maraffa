using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaraffaClient
{
    //Enumeratore dei semi delle carte
    public enum Seed
    {
        Bastoni,
        Coppe,
        Denari,
        Spade
    }

    // Enumeratore per i valori delle carte
    enum Value
    {
        Quattro = 0,
        Cinque,
        Sei,
        Sette,
        Fante,
        Cavallo,
        Re,
        Asso,
        Due,
        Tre
    }

    class Card
    {
        Value value;
        /*Valore delle carte è il seguente:
         * 4 => value = 1
         * 5 => value = 2
         * 6 => value = 3
         * 7 => value = 4
         * Fante => value = 5
         * Cavallo => value = 6
         * Re => value = 7
         * Asso => value = 8
         * 2 => value = 9
         * 3 => value = 10
         */
        Seed cardSeed;

        public Card(Value value, Seed cardSeed)
        {
            if(value < 0)
                throw new Exception("Valore inserito non valido");
            else
                this.value = value;

            this.cardSeed = cardSeed;
        }

        public Value Value
        {
            get
            {
                return value;
            }

            set
            {
                if (value < 0)
                    throw new Exception("Valore inserito non valido");
                else
                    this.value = value;
            }
        }

        public Seed CardSeed
        {
            get
            {
                return cardSeed;
            }
        }

        //public static bool operator >(Card c1, Card c2)
        //{
        //    return true;
        //}
    }
}
