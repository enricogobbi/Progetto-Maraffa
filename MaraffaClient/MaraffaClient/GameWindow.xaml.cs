using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;

namespace MaraffaClient
{
    /// <summary>
    /// Logica di interazione per GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        // costanti globali
        const int MAX_LENGTH = 150;                             // dimensione massima del pacchetto dati da inviare

        // variabili globali
        public static int localId;                              // id del giocatore locale
        int playedCards = 0;
        string word;                                            // parola da inviare 
        bool playToken = false;                                 // token che indica se il giocatore può giocare una carta o meno
        Seed validSeed;                                         // seme dominante della mano corrente
        public static Thread tListen;                           // thread che si mette in ascolto per ricevere i comandi
        Thread tCloser;

        // collezioni globali
        byte[] packet = new byte[MAX_LENGTH];                   // pacchetto di dati da inviare
        Hand localHand;                                         // mano del giocatore locale     
        Image[] imagesPaths;                                    // percorsi delle immaggini delle carte che il giocatore ha in mano
        bool first;

        //Window per gestione SCORE
        ScoreWindow scoreWindow = new ScoreWindow();


        //**********************METODI RELATIVI ALLA FINESTRA***************************************

        public GameWindow()
        {
            InitializeComponent();
            ActivateChat(Visibility.Hidden);
            imagesPaths = new Image[10] {img1, img2, img3, img4, img5, img6, img7, img8, img9,img10};
            tListen = new Thread(new ThreadStart(ListenSocket));
            tListen.Start();

            tCloser = new Thread(DisconnectController);
            tCloser.Start();
        }

        private void DisconnectController()
        {
            while (true)
            {
                if (!MainWindow.sck.Connected)
                {
                    tListen.Interrupt();
                    MessageBox.Show("Connessione interrotta");
                    this.Close();
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //MainWindow.sck.Close();
            //tListen.Interrupt();
        }

        public void DeactiveWindow(bool state)
        {
            this.IsEnabled = state;
        }

        public void ClearWindows(Image[] img, Label[] lbl)
        {
            for (int x = 0; x < 4; x++)
            {
                Action ac = () => 
                {
                    img[x].Source = new BitmapImage(new Uri(@"Dorso.png", UriKind.Relative));
                    lbl[x].Content = "";
                };
                Dispatcher.Invoke(ac);
            }
        }


        //**********************IDENTIFICAZIONE E SELEZIONE CARTE***************************************

        //metodo per decodificare il seme
        private Seed DecodeSeed(string input)
        {
            for (Seed s = 0; s <= Seed.Spade; s++)
                if (input == s.ToString())
                    return s;

            return Seed.Bastoni;
        }

         // metodo per la selezione della carta
        private void SelectCard(int index)
        {
            if (localHand.Vseed)
            {
                if (localHand[index].CardSeed == validSeed)
                    SendMessage(index);
                else
                    throw new Exception("Carta non valida, selezionarne una di " + validSeed);
            }
            else
                SendMessage(index);
        }


        //**********************INVIO E RICEZIONE MESSAGGI**********************************************

        // metodo per codificare il comando da inviare
        private void SendMessage(int index)
        {
            string mess = "PLAY" + localHand[index].Value + "," + localHand[index].CardSeed;

            // aggiunta dell'eventuale parola
            if (word != "")
                mess += "," + word;

            // invio del messaggio
            MainWindow.sck.Send(Encoding.UTF8.GetBytes(mess));

            // rimozione carta dalla mano e del token
            localHand[index] = null;
            playToken = false;

            if (first)
            {
                if (playedCards >= 4)
                {
                    Image[] imgVett = new Image[] { img_Card1, img_Card2, img_Card3, img_Card4 };
                    Label[] lblVett = new Label[] { lbl_Messaggio1, lbl_Messaggio2, lbl_Messaggio3, lbl_Messaggio4 };

                    ClearWindows(imgVett, lblVett);

                    playedCards = 0;
                }
            }

            // modifica della grafica
            Action ac = () =>
            {
                img_Card1.Source = imagesPaths[index].Source;
                imagesPaths[index].Source = new BitmapImage(new Uri(@"Dorso.png", UriKind.Relative));
                btn_Rosso.Background = Brushes.Red;
                btn_Verde.Background = Brushes.Transparent;
                btn_Chat.IsEnabled = false;
            };
            Dispatcher.Invoke(ac);

            

            playedCards++;
        }

        // metodo che si mette in ascolto sulla socket per la ricezione dei comandi
        private void ListenSocket()
        {
            while (true)
            {
                byte[] mex = new byte[MAX_LENGTH];

                try
                {
                    MainWindow.sck.Receive(mex);

                    // variaibili locali
                    string command = Encoding.UTF8.GetString(mex);                  // comando ricevuto nel pacchetto
                    string[] param;                                                 // parametri ricevuti dal pacchetto

                    command = command.Trim('\0');

                    // esecuzione del comando SHOW
                    if (command.IndexOf("SHOW") == 0)
                    {
                        param = command.Substring("SHOW ".Length).Split(',');
                        int cont = localId, cardPosition = 0;
                        Image[] img = new Image[] { img_Card1, img_Card2, img_Card3, img_Card4 };
                        Label[] lbl = new Label[] { lbl_Messaggio1, lbl_Messaggio2, lbl_Messaggio3, lbl_Messaggio4 };

                        if (playedCards >= 4)
                        {
                            ClearWindows(img, lbl);
                            playedCards = 0;
                        }

                        while (cont != int.Parse(param[2]))
                        {
                            cardPosition++;
                            cont++;

                            if (cont == 4)
                                cont = 0;

                            if (cont == int.Parse(param[2]))
                            {
                                // visualizzazione carta ricevuta
                                string uri = @"Carte/" + @param[0] + @param[1].TrimStart(' ') + ".png";                                             // generazione del path

                                Action ac = () => { img[cardPosition].Source = new BitmapImage(new Uri(uri, UriKind.RelativeOrAbsolute)); };
                                Dispatcher.Invoke(ac);

                                // eventuale visualizzazione della parola ricevuta
                                if (param.Length == 4)
                                {
                                    ac = () => { lbl[cardPosition].Content = param[3]; };
                                    Dispatcher.Invoke(ac);
                                }

                                // rimozione delle carte appena giocate al termine della mano
                                playedCards++;
                            }
                        }
                    }
                    // esecuzione comando TURN
                    else if (command.IndexOf("TURN") == 0)
                    {
                        playToken = true;

                        command = command.TrimEnd(' ');
                        // modifica del semaforo
                        Action ac = () => { btn_Rosso.Background = Brushes.Transparent; btn_Verde.Background = Brushes.LawnGreen; /*lbl_Messaggio1.Content = command + ".";*/ };
                        Dispatcher.Invoke(ac);

                        if (command.Length > 4)
                        {
                            validSeed = DecodeSeed(command.Substring("TURN ".Length));
                            localHand.ValidCards(validSeed);
                            first = false;
                        }
                        else
                        {
                            localHand.Vseed = false;
                            Action chatAction = () => { btn_Chat.IsEnabled = true; };
                            Dispatcher.Invoke(chatAction);
                            first = true;
                        }
                    }
                    // esecuzione del comando BRIS
                    else if (command.IndexOf("BRIS") == 0)
                    {
                        if (command.Length == 4)
                        {
                            Action ac = () => { new BriscolaWindow(this).ShowDialog(); };                                                                                            // apertura della finestra di scelta della briscola                   
                            Dispatcher.Invoke(ac);
                        }
                        else
                        {
                            Action ac = () => { img_Briscola.Source = new BitmapImage(new Uri(@"Semi/" + @command.Substring(5) + ".png", UriKind.Relative)); /*lbl_Messaggio1.Content = command + "."; */};            // visualizzazione del seme briscola ricevuto
                            Dispatcher.Invoke(ac);
                        }

                    }
                    // esecuzione del comando HAND
                    else if (command.IndexOf("HAND") == 0)
                    {
                        param = command.Substring("HAND ".Length).Split(',');
                        List<Card> hand = new List<Card>();

                        // ciclo per identificare le carte
                        for (int x = 0; x < 10; x++)
                        {
                            // variabili locali 
                            Seed currentSeed = Seed.Bastoni;                                    // seme della carta corrente

                            // decodifica del seme 
                            currentSeed = DecodeSeed(param[x].Substring(param[x].IndexOf(' ')+1));

                            // decodifica del valore
                            for (Value v = 0; v <= Value.Tre; v++)
                                if (param[x].Substring(0, param[x].IndexOf(' ')) == v.ToString())
                                {
                                    // aggiunta della carta alla mano
                                    hand.Add(new Card(v, currentSeed));
                                    break;
                                }
                        }

                        localHand = new Hand(hand);
                        for(int x = 0; x < hand.Count; x++)
                        {
                            Action ac = () => { imagesPaths[x].Source = new BitmapImage(new Uri(@"Carte/" + localHand[x].Value.ToString() + localHand[x].CardSeed.ToString() + ".png", UriKind.Relative)); };
                            Dispatcher.Invoke(ac);
                        }
                    }
                    // esecuzione del comando SCORE
                    else if (command.IndexOf("SCORE") == 0)
                    {
                        param = command.Substring("SCORE ".Length).Split(',');

                        Action ac = () =>
                        {
                            scoreWindow.AddScore(int.Parse(param[0]), int.Parse(param[1]));
                        };
                        Dispatcher.InvokeAsync(ac);

                        if (param.Length == 3)
                        {
                            MessageBox.Show("PARTITA TERMINATA!\nLa squadra " + param[2] + " ha vinto la partita!", "Partita terminata");
                            MainWindow.sck.Close();
                        }
                    }
                    else if (command.IndexOf("MARAFFA") == 0)
                    {
                        param = command.Substring("MARAFFA ".Length).Split(',');
                        validSeed = DecodeSeed(param[0]);

                        MainWindow.sck.Send(Encoding.UTF8.GetBytes("BRIS " + validSeed.ToString()));
                        SelectCard(int.Parse(param[1]));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        //**********************BOTTONI DELLE CARTE*****************************************************

        private void buttonPress(int index)
        {
            try
            {
                if (playToken)
                    if (localHand[index] != null)
                        SelectCard(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Card1_Click(object sender, RoutedEventArgs e)
        {
            buttonPress(0);
        }

        private void btn_Card2_Click(object sender, RoutedEventArgs e)
        {
            buttonPress(1);
        }

        private void btn_Card3_Click(object sender, RoutedEventArgs e)
        {
            buttonPress(2);
        }

        private void btn_Card4_Click(object sender, RoutedEventArgs e)
        {
            buttonPress(3);
        }

        private void btn_Card5_Click(object sender, RoutedEventArgs e)
        {
            buttonPress(4);
        }

        private void btn_Card6_Click(object sender, RoutedEventArgs e)
        {
            buttonPress(5);
        }

        private void btn_Card7_Click(object sender, RoutedEventArgs e)
        {
            buttonPress(6);
        }

        private void btn_Card8_Click(object sender, RoutedEventArgs e)
        {
            buttonPress(7);
        }

        private void btn_Card9_Click(object sender, RoutedEventArgs e)
        {
            buttonPress(8);
        }

        private void btn_Card10_Click(object sender, RoutedEventArgs e)
        {
            buttonPress(9);
        }




        //****************************** BOTTONI DELLA CHAT ********************************************
       
        // metodo per attivare la chat
        private void ActivateChat(Visibility value)
        {
            btn_Busso.Visibility = value;
            btn_Striscio.Visibility = value;
            btn_Volo.Visibility = value;
            btn_None.Visibility = value;
        }

        private void btn_Chat_Click(object sender, RoutedEventArgs e)
        {
            if (btn_Busso.Visibility == Visibility.Hidden)
                ActivateChat(Visibility.Visible);
            else
                ActivateChat(Visibility.Hidden);
        }

        private void btn_Volo_Click(object sender, RoutedEventArgs e)
        {
            word = "Volo";
            lbl_Messaggio1.Content = "Volo";
            ActivateChat(Visibility.Hidden);
        }

        private void btn_Busso_Click(object sender, RoutedEventArgs e)
        {
            word = "Busso";
            lbl_Messaggio1.Content = "Busso";
            ActivateChat(Visibility.Hidden);
        }

        private void btn_Striscio_Click(object sender, RoutedEventArgs e)
        {
            word = "Striscio";
            lbl_Messaggio1.Content = "Striscio";
            ActivateChat(Visibility.Hidden);
        }

        private void btn_None_Click(object sender, RoutedEventArgs e)
        {
            word = "";
            lbl_Messaggio1.Content = "";
            ActivateChat(Visibility.Hidden);
        }





        private void btn_Punteggio_Click(object sender, RoutedEventArgs e)
        {
            scoreWindow.ShowScore();
        }
    }
}
