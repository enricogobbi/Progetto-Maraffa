using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace MaraffaServerConsole
{
    class Server
    {
        const int PORT = 60102;
        Socket sck;
        static List<Client> clients;
        int nConn = 0;


        public Server()
        {
            clients = new List<Client>();

            sck = new Socket(SocketType.Stream, ProtocolType.IP);
            sck.Bind(new IPEndPoint(IPAddress.Parse(/*LocalIP()*/"127.0.0.1"), PORT));
            sck.Listen(150);
        }

        //Metodo per invio del comando SHOW
        private void Show(object sender, EventArgs e)
        {
            Client c = sender as Client;
            Helper h = e as Helper;

            Card card = h.Card;

            for(int i = 0; i < 4; i++)
            {
                //invio ai giocatori la giocata
                if (clients[i].Id != c.Id)
                {
                    if(h.Word != "")
                        clients[i].SendMsg(string.Format("SHOW {0},{1},{2}"/*,{3}"*/, card.Value, card.CardSeed, c.Id/*, h.Word*/));
                    else
                        clients[i].SendMsg(string.Format("SHOW {0},{1},{2}", card.Value, card.CardSeed, c.Id));
                }
            }
        }

        //Metodo per invio del comando HAND
        private void Hand(object sender, EventArgs e)
        {
            Player p = sender as Player;
            string s = "";

            //Composizione della stringa per invio della mano
            for(int i = 0; i < 10; i++)
            {
                s += p.Hand[i].Value.ToString() + " " + p.Hand[i].CardSeed.ToString();
                s += ",";
            }

            p.Client.SendMsg("HAND " + s);
        }

        public void ServerAccept(Player[] players)
        {
            int nConn = 0;

            while (nConn < 4)
            {
                string nick = "";
                byte[] buffer = new byte[1024];
                UTF8Encoding encoder = new UTF8Encoding();

                // Attende una connessione client
                Socket clnt = sck.Accept();

                //MessageBox.Show("Accettata connessione client {0}", clnt.RemoteEndPoint.ToString());

                // Avvia la gestione del client
                Client client = new Client(clnt, nConn);
                clients.Add(client);

                //Ricezione Nickname
                clnt.Receive(buffer);
                nick = encoder.GetString(buffer);

                //Estrazione Nickname
                nick = nick.Substring(5);
                nick = nick.Trim('\0');

                if (nConn < 1)
                    players[nConn] = new Player(nick, 1, client, nConn);
                else
                    players[nConn] = new Player(nick, 2, client, nConn);

                //Invio ID al giocatore
                players[nConn].Client.SendMsg(string.Format("{0}", players[nConn].Id));

                nConn++;
            }

            //inizializzazione gestore evento ReceivedPlay
            for (int i = 0; i < 4; i++)
            {
                clients[i].ReceivedPlay += Show;
            }

            //inizializzazione gestore evento SetHand
            for (int i = 0; i < 4; i++)
            {
                players[i].SetHand += Hand;
            }
        }

        //Utilizzato questo
        public Player ServerAccept()
        {
            Player p;

            string nick = "";
            byte[] buffer = new byte[1024];
            UTF8Encoding encoder = new UTF8Encoding();

            // Attende una connessione client
            Socket clnt = sck.Accept();

            //MessageBox.Show("Accettata connessione client {0}", clnt.RemoteEndPoint.ToString());

            // Avvia la gestione del client
            Client client = new Client(clnt, nConn);
            clients.Add(client);

            //Ricezione Nickname
            clnt.Receive(buffer);
            nick = encoder.GetString(buffer);

            //Estrazione Nickname
            nick = nick.Substring(5);
            nick = nick.Trim('\0');

            if (nConn < 1)
                p = new Player(nick, 1, client, nConn);
            else
                p = new Player(nick, 2, client, nConn);

            //Invio ID al giocatore
            p.Client.SendMsg(string.Format("{0}", p.Id));

            //inizializzazione gestore evento ReceivedPlay
            clients[nConn].ReceivedPlay += Show;

            //inizializzazione gestore evento SetHand
            p.SetHand += Hand;

            nConn++;

            return p;
        }

        //Metodo per chiusura delle socket
        public void Close()
        {
            try
            {
                for (int i = 0; i < 4; i++)
                {
                    clients[i].Socket.Close();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Metodo per restituzione indirizzo IP della macchina
        public static string LocalIP()
        {
            //Prelevazione del IP del Server
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork" && ip.ToString() != "192.168.56.1")
                {
                    return ip.ToString();
                }
            }

            throw new Exception("IP non trovato");
        }

        public static List<Client> Clients
        {
            get { return clients; }
        }
    }
}
