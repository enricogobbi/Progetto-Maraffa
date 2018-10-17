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
using System.Windows.Forms;


namespace MaraffaClient
{
    /// <summary>
    /// Logica di interazione per BriscolaWindow.xaml
    /// </summary>
    public partial class BriscolaWindow : Window
    {
        // costanti globali
        const int MAX_LENGTH = 150;                         // massima lunghezza del pacchetto 

        // variabili globali
        string command;                                     // comando da inviare

        GameWindow game;

        public BriscolaWindow(GameWindow currGame)
        {
            InitializeComponent();
            game = currGame;
            //game.DeactiveWindow(false)         
        }

        // metodo per la selezione e la codifica e l'invio della briscola
        private void SelectBriscola(Seed s)
        {
            command = "BRIS " + s;

            MainWindow.sck.Send(Encoding.UTF8.GetBytes(command));
            game.DeactiveWindow(true);
        }

        private void btn_Bastoni_Click(object sender, RoutedEventArgs e)
        {
            SelectBriscola(Seed.Bastoni);

            this.Close();
        }

        private void btn_Coppe_Click(object sender, RoutedEventArgs e)
        {
            SelectBriscola(Seed.Coppe);

            this.Close();
        }

        private void btn_Denari_Click(object sender, RoutedEventArgs e)
        {
            SelectBriscola(Seed.Denari);

            this.Close();
        }

        private void btn_Spade_Click(object sender, RoutedEventArgs e)
        {
            SelectBriscola(Seed.Spade);

            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //new GameWindow().IsEnabled = true;
        }
    }
}
