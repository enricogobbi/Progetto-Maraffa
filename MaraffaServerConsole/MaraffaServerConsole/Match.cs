using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaraffaServerConsole
{
    //Classe per gestione della mano (10 giocate)
    class Match
    {
        CompleteDeck deck;

        TeamDeck firstTeamDeck;
        TeamDeck secondTeamDeck;
        int scoreFirst = 0;
        int scoreSecond = 0;

        Seed briscola;
        Player[] players;
        bool firstHand;
        int dealer = 0;
        int handCount = 0;
        bool maraffa = false;

        public event EventHandler BriscolaEvent;


        public Match(Player[] players)
        {
            this.players = players;
            deck = new CompleteDeck();
            firstTeamDeck = new TeamDeck();
            secondTeamDeck = new TeamDeck();
            firstHand = true;
        }

        public void NewHand()
        {
            maraffa = false;
            Seed s = 0;

            int i = 0;
            List<Card>[] hand = new List<Card>[4];

            deck = new CompleteDeck();
            firstTeamDeck = new TeamDeck();
            secondTeamDeck = new TeamDeck();

            deck.Mix();
            deck.Cut();

            //Assegnazione delle mani
            hand[0] = new List<Card>();
            hand[1] = new List<Card>();
            hand[2] = new List<Card>();
            hand[3] = new List<Card>();

            //Assegnazione del primo giocatore della nuova mano
            if (!firstHand)
            {
                if (dealer == 3)
                    dealer = 0;
                else
                    dealer++;
            }

            int k = dealer;

            //Creazione mani
            while (i < 40)
            {
                hand[k].Add(deck[i]);

                //Quando il numero della carta è multiplo di 5 allora o si danno le carte al giocatore successivo
                if ((i + 1) % 5 == 0)
                {
                    if (k != 3)
                        k++;
                    else
                        k = 0;
                }

                i++;
            }


            if (firstHand)
            {
                for (int j = 0; j < 4; j++)
                {

                    //Identificazione del possessore del 4 di Denari per assegnazione del turnToken
                    if (hand[j].Contains(new Card(Value.Quattro, Seed.Denari)))
                    {
                        dealer = j;
                    }

                }
            }

            //dealer = 3;
            //hand[3][0] = new Card(Value.Asso, Seed.Coppe);
            //hand[3][1] = new Card(Value.Due, Seed.Coppe);
            //hand[3][2] = new Card(Value.Tre, Seed.Coppe);

            //Creazione delle mani
            players[0].Hand = new Hand(hand[0]);
            players[1].Hand = new Hand(hand[1]);
            players[2].Hand = new Hand(hand[2]);
            players[3].Hand = new Hand(hand[3]);

            for(int j = 0; j < 4; j++)
            {
                if(players[dealer].Hand.EntireHand.Contains(new Card(Value.Asso, (Seed)j)) && players[dealer].Hand.EntireHand.Contains(new Card(Value.Due, (Seed)j)) && players[dealer].Hand.EntireHand.Contains(new Card(Value.Tre, (Seed)j)))
                {
                    maraffa = true;
                    s = (Seed)j;
                }
            }

            var delay = Task.Run(async () =>
            {
                await Task.Delay(400);
                return true;
            });

            bool prova = delay.Result;

            if (!maraffa)
            {
                players[dealer].BriscolaToken = true;
                players[dealer].BriscolaToken = false;
            }
            else
            {
                int index = 0;

                for (int j = 0; j < 10; j++)
                {
                    if(players[dealer].Hand.EntireHand[j].Value == Value.Asso && players[dealer].Hand.EntireHand[j].CardSeed == s)
                    {
                        index = j;
                    }
                }

                players[dealer].Client.SendMsg(string.Format("MARAFFA {0},{1}", s.ToString(), index));

            }

            firstHand = false;
        }

        public void SetBriscola(Seed b)
        {
            briscola = b;

            if (!maraffa)
            {
                players[dealer].PlayToken = true;
                players[dealer].PlayToken = false;

                var delay = Task.Run(async () =>
                {
                    await Task.Delay(400);
                    return true;
                });

                bool prova = delay.Result;
            }

            if (BriscolaEvent != null)
                BriscolaEvent(this, new Helper(Briscola));
        }

        //Prevede che venga passata la lista con le carte in ordine di gioco e l'ordine di gioco
        public int HandWinner(List<Card> giocata)
        {
            Seed baseSeed = giocata[0].CardSeed; //Restituisce il seme che "comanda"
            Card winner = giocata[0];
            int idWin = 0;

            //Seme che comanda == Briscola
            if (baseSeed == Briscola)
            {
                //Scorre tutta la lista contenente le carte giocate
                for (int i = 1; i < 4; i++)
                {
                    //Verifica se il seme della carta è anch'essa briscola altrimenti viene ignorata
                    if (giocata[i].CardSeed == Briscola)
                    {
                        //Verifica se valore della carta è > del valore della carta più alta finora
                        if (giocata[i].Value > winner.Value)
                        {
                            winner = giocata[i];
                        }
                    }
                }
            }
            else //Seme che comanda != Briscola
            {
                //Scorre tutta la lista contenente le carte giocate partendo da index = 1 poiché la prima carta è di default la vincitrice
                for (int i = 1; i < 4; i++)
                {
                    if (baseSeed == briscola)
                    {
                        //Verifica se la carta è anch'essa del seme che comanda
                        if (giocata[i].CardSeed == baseSeed)
                        {
                            //Verifica se valore della carta è > del valore della carta più alta finora
                            if (giocata[i].Value > winner.Value)
                            {
                                winner = giocata[i];
                            }
                        }

                        //se non è briscola ignora la carta
                    }
                    else
                    {
                        //Verifica se il seme della carta è anch'essa del seme che comanda e 
                        if (giocata[i].CardSeed == baseSeed && winner.CardSeed != briscola)
                        {
                            //Verifica se valore della carta è > del valore della carta più alta finora
                            if (giocata[i].Value > winner.Value)
                            {
                                winner = giocata[i];
                            }
                        }
                        else //Carta non del seme che comanda
                        {
                            //Verifica se la carta è una briscola
                            if (giocata[i].CardSeed == briscola)
                            {
                                //Verifica se è una briscola e il seme della carta alta non lo è 
                                if (winner.CardSeed != briscola)
                                {
                                    winner = giocata[i];
                                }
                                else
                                {
                                    //Se anche la carta alta è briscola allora verifica il valore
                                    if (giocata[i].Value > winner.Value)
                                    {
                                        winner = giocata[i];
                                    }
                                }
                            }

                            //se non è ne briscola ne del seme che comanda la carta verrà ignorata
                        }
                    }
                }
            }

            //Ricerca chi ha giocato la carta alta
            for(int i = 0; i < 4; i++)
            {
                if (players[i].Hand.EntireHand.Contains(winner))
                {
                    idWin = players[i].Id;
                    break;
                }
            }

            handCount++;

            //Individuazione team del giocatore che prende e aggiunta al mazzo corrispettivo
            if(players[idWin].Team == 1)
            {
                firstTeamDeck.AddCard(giocata);
            }
            else
            {
                secondTeamDeck.AddCard(giocata);
            }

            return idWin;
        }

        public Player[] Players
        {
            get { return players; }
        }

        public TeamDeck FirstTeamDeck
        {
            get { return firstTeamDeck; }
        }

        public TeamDeck SecondTeamDeck
        {
            get { return secondTeamDeck; }
        }

        public Seed Briscola
        {
            get { return briscola; }
        }

        public int ScoreFirst
        {
            get { return scoreFirst; }
            set { scoreFirst = value; }
        }

        public int ScoreSecond
        {
            get { return scoreSecond; }
            set { scoreSecond = value; }
        }

        public int Dealer
        {
            get { return dealer; }
            set { dealer = value; }
        }

        public int HandCount
        {
            get { return handCount; }
            set { handCount = value; }
        }

        public bool FirstHand
        {
            get { return firstHand; }
        }
    }
}
