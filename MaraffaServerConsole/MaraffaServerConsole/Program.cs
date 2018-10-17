using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MaraffaServerConsole
{
    class Program
    {
        static Server srv;
        static Thread thrdLstn;                                                    //Thread listener

        //Variabili per gestione partita
        internal static Match match;
        static Player[] players = new Player[4];
        internal static List<Card> giocata = new List<Card>(4);
        static bool firstPlay = true;

        static void Main(string[] args)
        {
            srv = new Server();
            Console.WriteLine("Start Server...");
            Console.WriteLine("In attesa di connesioni IP: {0}"/*, Server.LocalIP()*/);

            giocata.Add(null);
            giocata.Add(null);
            giocata.Add(null);
            giocata.Add(null);

            thrdLstn = new Thread(AcceptConnections);

            try
            {
                thrdLstn.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                Console.WriteLine();

                Console.ReadKey();
            }
        }

        //Metodo per ThreadListener
        static void AcceptConnections()
        {
            //srv.ServerAccept(players);

            for (int i = 0; i < 4; i++)
            {
                players[i] = srv.ServerAccept();
                
                Console.WriteLine("Connesso {0}",players[i].Nickname + players[i].Client.Socket.RemoteEndPoint.ToString());
            }

            //for (int i = 0; i < 4; i++)
            //{
            //    lst_Connessi.Items.Add(players[i].Nickname + players[i].Socket.RemoteEndPoint.ToString());
            //}

            //lbl_Connessi.Content = "Utenti connessi: 4";

            match = new Match(players);

            //Inizializzazione gestore evento ToSetBriscola, Turn e ReceivedPlay
            for (int i = 0; i < 4; i++)
            {
                players[i].Turn += NotifyTurn;
                players[i].ToSetBriscola += NotifyBriscola;
                players[i].Client.ReceivedPlay += PlayedCard;
            }

            match.BriscolaEvent += SendBriscola;

            match.NewHand();
        }

        //Metodo per aggiunta carta alla giocata in seguito alla giocata di una carta
        static void PlayedCard(object sender, EventArgs e)
        {
            Helper h = e as Helper;
            Card card = h.Card;
            Client client = sender as Client;
            int idWin;

            if (firstPlay)
            {
                giocata.Clear();
                firstPlay = false;
            }

            giocata.Add(card);

            if (giocata.Count == 4)
            {
                idWin = match.HandWinner(giocata);

                giocata.Clear();
                giocata.Add(null);
                giocata.Add(null);
                giocata.Add(null);
                giocata.Add(null);
                firstPlay = true;

                if (match.HandCount == 10)
                {
                    if (players[idWin].Team == 1)
                    {
                        match.ScoreFirst += match.FirstTeamDeck.CalcScore(true);
                        match.ScoreSecond += match.SecondTeamDeck.CalcScore(false);
                    }
                    else
                    {
                        match.ScoreFirst += match.FirstTeamDeck.CalcScore(false);
                        match.ScoreSecond += match.SecondTeamDeck.CalcScore(true);
                    }

                    match.HandCount = 0;

                    //Comunicazione score dei team ai client per aggiornamento punteggi
                    for (int i = 0; i < 4; i++)
                    {
                        if (match.ScoreFirst >= 41)
                            players[i].Client.SendMsg(string.Format("SCORE {0},{1},{2}", match.ScoreFirst, match.ScoreSecond, "1"));
                        else if (match.ScoreSecond >= 41)
                            players[i].Client.SendMsg(string.Format("SCORE {0},{1},{2}", match.ScoreFirst, match.ScoreSecond, "2"));
                        else
                            players[i].Client.SendMsg(string.Format("SCORE {0},{1}", match.ScoreFirst, match.ScoreSecond));
                    }

                    match.NewHand();
                }
                else
                {
                    //Selezione nuovo dealer cioè colui che inizierà la mano successiva
                    players[idWin].PlayToken = true;
                    players[idWin].PlayToken = false;
                }
            }
            else
            {
                //Reinserire il turnId
                int turnId;

                //Se non è finito il giro modifica il playToken per il giocatore successivo
                if (client.Id == 3)
                    turnId = 0;
                else
                    turnId = client.Id + 1;

                match.Players[turnId].PlayToken = true;
                match.Players[turnId].PlayToken = false;
            }
        }

        //Metodo per notifica del proprio turno tramite comando TURN
        static private void NotifyTurn(object sender, EventArgs e)
        {
            string mess = "";

            Player p = sender as Player;

            if (giocata[0] == null)
                mess = "TURN ";
            else
                mess = "TURN " + (giocata[0].CardSeed).ToString();

            p.Client.SendMsg(mess);
        }

        //Metodo per notifica del proprio turno di briscola tramite comando BRIS
        static private void NotifyBriscola(object sender, EventArgs e)
        {
            string mess = "";

            Player p = sender as Player;

            mess = "BRIS";

            if (p.Id == 3)
                p.Client.SendMsg(mess);
            else
                p.Client.SendMsg(mess);
        }

        //Metodo per comunicazione briscola a tutti i giocatori
        static private void SendBriscola(object sender, EventArgs e)
        {
            string mess = "";

            Player p = sender as Player;

            mess = string.Format("BRIS {0}", match.Briscola.ToString());

            for (int i = 0; i < 4; i++)
            {
                players[i].Client.SendMsg(mess);
            }
        }
    }
}
