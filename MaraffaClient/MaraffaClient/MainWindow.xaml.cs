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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace MaraffaClient
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // costanti globali
       const int SERVER_PORT = 60102;                   // porta su cui comunicheranno i client e il server

        // variabili globali
       public static Socket sck;                        // socket che mettera in comunicazione i client e il server

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Connect_Click(object sender, RoutedEventArgs e)
        {
            string mex;
            byte[] id = new byte[10];

            try
            {
                sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(txt_ServerAddress.Text), SERVER_PORT);

                mex = "NICK " + txt_Nome.Text;

                sck.Connect(ep);

                if (sck.Connected)
                {
                    sck.Send(Encoding.UTF8.GetBytes(mex));
                    sck.Receive(id);

                    GameWindow.localId = int.Parse(Encoding.UTF8.GetString(id));

                    new GameWindow().Show();
                    this.Close();
                }
                else
                    throw new Exception("Impossibile connettersi al server");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
