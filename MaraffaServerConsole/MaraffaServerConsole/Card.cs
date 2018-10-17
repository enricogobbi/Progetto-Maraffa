using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaraffaServerConsole
{
    //Enumeratore dei semi delle carte
    enum Seed
    {
        Bastoni,
        Coppe,
        Denari,
        Spade
    }

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

    class Card : IEquatable<Card>
    {
        Value value;
        /*Valore delle carte è il seguente:
         * 4 => value = 0
         * 5 => value = 1
         * 6 => value = 2
         * 7 => value = 3
         * Fante => value = 4
         * Cavallo => value = 5
         * Re => value = 6
         * Asso => value = 7
         * 2 => value = 8
         * 3 => value = 9
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

        public bool Equals(Card c)
        {
            if (this.value == c.Value && this.cardSeed == c.CardSeed)
                return true;
            else
                return false;
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
        //    if (c1.Value > c2.Value)
        //        return true;
        //    else
        //        return false;
        //}

        //public static bool operator <(Card c1, Card c2)
        //{
        //    if (c1.Value > c2.Value)
        //        return true;
        //    else
        //        return false;
        //}
    }
}
