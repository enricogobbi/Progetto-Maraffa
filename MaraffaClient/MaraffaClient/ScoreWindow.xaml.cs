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

namespace MaraffaClient
{
    /// <summary>
    /// Logica di interazione per ScoreWindow.xaml
    /// </summary>
    public partial class ScoreWindow : Window
    {
        static int ScoreTeam1 = 0;
        static int ScoreTeam2 = 0;
        bool isVisible = false;
        
        public ScoreWindow()
        {
            InitializeComponent();
        }

        public void AddScore(int score1, int score2)
        {
            // aggiornamento della grafica
            lst_Squadra1.Items.Add(score1-ScoreTeam1);
            lst_Squadra2.Items.Add(score2-ScoreTeam2);
            lbl_Tot1.Content = score1;
            lbl_Tot2.Content = score2;

            // aggiornamento score totale
            ScoreTeam1 = score1;
            ScoreTeam2 = score2;
        }

        public void ShowScore()
        {
            if (!isVisible)
            {
                this.Visibility = Visibility.Visible;
                isVisible = true;
            }
            else
            {
                this.Visibility = Visibility.Hidden;
                isVisible = false;
            }      
        }

    }
}
