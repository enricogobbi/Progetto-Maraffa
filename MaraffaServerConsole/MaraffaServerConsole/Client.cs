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
    class Helper : EventArgs
    {
        public Card Card { get; }
        public string Word { get; }
        public Seed Brisc { get; }
        public int ScoreFirst { get; }
        public int ScoreSecond { get; }

        public Helper(Card card, string word)
        {
            Card = card;
            Word = word;
        }

        public Helper(Seed brisc)
        {
            Brisc = brisc;
        }

        public Helper(int s1, int s2)
        {
            ScoreFirst = s1;
            ScoreSecond = s2;
        }
    }

    class Client
    {
        private Socket sck;
        private Thread thrd;
        private int id;

        public event EventHandler ReceivedPlay;

        public Client(Socket sck, int id)
        {
            this.id = id;

            this.sck = sck;
            thrd = new Thread(ClientLoop);
            thrd.Start();
        }

        private string ReceiveCommand()
        {
            const int MAX_LINE_LEN = 150; //Limite lunghezza

            byte[] buffer = new byte[150];
            string res = "";
            UTF8Encoding encoder = new UTF8Encoding();

            try
            {
                //Ricezione comando
                sck.Receive(buffer);
                res = encoder.GetString(buffer);
                //Eliminazione spazi vuoti
                res = res.Trim('\0');
                //Controllo sulla lunghezza
                if (res.Length > MAX_LINE_LEN)
                    throw new Exception("Line too long");

                return res;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ClientLoop()
        {
            string command;

            //Ciclo continuo sempre in ascolto per ogni client
            while (true)
            {
                command = ReceiveCommand();

                //Da togliere il writeline e inserirlo nel main
                Console.WriteLine("Received {0} from {1}", command, this.sck.RemoteEndPoint.ToString());

                //Esegue quando a inizio comando è presente la stringa "PLAY"
                if (command.IndexOf("PLAY") == 0)
                {
                    string word = "";

                    //Estrazione parametri
                    string param = command.Substring("PLAY".Length).Trim();

                    if (param == "")
                    {
                        SendMsg("ERROR Parametri non validi");
                        continue;
                    }

                    //Gestione giocata delle carta
                    {
                        string[] tmp;
                        Seed s = 0;
                        Value v = 0;

                        tmp = param.Split(',');

                        //Verifica primo parametro
                        for (Value val = 0; val <= Value.Tre; val++)
                        { 
                            if (tmp[0].ToLower() == val.ToString().ToLower())
                            {
                                v = val;
                            }
                        }

                        //Verifica secondo parametro
                        for (Seed val = 0; val <= Seed.Spade; val++)
                        {
                            if (tmp[1].ToLower() == val.ToString().ToLower())
                            {
                                s = val;
                            }
                        }

                        if (tmp.Length == 3)
                            word = tmp[2];

                        //Scateno evento
                        if (ReceivedPlay != null)
                            ReceivedPlay(this, new Helper(new Card(v, s), word));
                    }
                }
                else if(command.IndexOf("BRIS") == 0)
                {
                    //Estrazione parametri
                    string param = command.Substring("BRIS".Length).Trim();

                    if (param == "")
                    {
                        SendMsg("ERROR Parametri non validi");
                        continue;
                    }

                    //Gestione set della briscola
                    switch (param.ToLower())
                    {
                        case "bastoni":
                            Program.match.SetBriscola(Seed.Bastoni);
                            break;

                        case "coppe":
                            Program.match.SetBriscola(Seed.Coppe);
                            break;

                        case "denari":
                            Program.match.SetBriscola(Seed.Denari);
                            break;

                        case "spade":
                            Program.match.SetBriscola(Seed.Spade);
                            break;
                    }
                }
            }
        }

        //Invio messaggi al client
        public void SendMsg(string msg)
        {
            byte[] buff = Encoding.UTF8.GetBytes(msg);
            sck.Send(buff, msg.Length, SocketFlags.None);

            //Da togliere il writeline e inserirlo nel main
            Console.WriteLine("Sended {0} to {1}", msg, this.sck.RemoteEndPoint.ToString());
        }

        public int Id
        {
            get { return id; }
        }

        public Socket Socket
        {
            get { return sck; }
        }

    }
}
