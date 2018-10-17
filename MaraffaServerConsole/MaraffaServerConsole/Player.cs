using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace MaraffaServerConsole
{
    class Player
    {
        string nickname;
        Client c;
        bool playToken = false;
        bool briscolaToken = false;
        int team;
        Hand hand;
        int id;

        public event EventHandler Turn;
        public event EventHandler ToSetBriscola;
        public event EventHandler SetHand;

        public Player(string nickname, int team, Client c, int id)
        {
            this.nickname = nickname;
            this.c = c;
            this.id = id;

            //Controllo che team sia corretto
            if (team == 1 || team == 2)
                this.team = team;
            else
                throw new Exception("Squadra inserita non valida");

            hand = new Hand();
        }

        //Varie proprietà
        public bool PlayToken
        {
            get { return playToken; }
            set
            {
                playToken = value;

                if (playToken == true)
                    if(Turn != null)
                        Turn(this, EventArgs.Empty);
            }
        }

        public bool BriscolaToken
        {
            get { return briscolaToken; }
            set
            {
                briscolaToken = value;

                if (briscolaToken == true)
                {
                    if (ToSetBriscola != null)
                    {
                        if (this.id == 3)
                        {
                            ToSetBriscola(this, EventArgs.Empty);
                        }
                        else
                            ToSetBriscola(this, EventArgs.Empty);
                    }
                }
                        
            }
        }

        public Card this [int i]
        {
            get
            {
                return hand[i];
            }
        }

        public int Team
        {
            get { return team; }
        }

        public int Id
        {
            get { return id; }
        }

        public string Nickname
        {
            get { return nickname; }
        }

        public Client Client
        {
            get { return c; }
        }

        public Hand Hand
        {
            get { return hand; }

            set
            {
                hand = value;

                if(SetHand != null)
                    SetHand(this, EventArgs.Empty);
            }
        }
    }
}
