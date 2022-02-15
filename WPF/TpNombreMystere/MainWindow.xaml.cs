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

namespace TpNombreMystere
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool trouve = false;
        static Random random = new Random();
        int essais = 0, mystere = random.Next(1, 51);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ValiderSaisie_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbEssai.Text, out int number))
            {
                essais++;
                trouve = mystere == number;
                if (!trouve)
                {
                    textRetour1.Text = $"C'est {(mystere < number ? "moins" : "plus")}...!";
                    lblNbEssais.Content = $"Nombre d'Essais : {essais}";
                }
                else
                {
                    textRetour1.Text = $"Bravo !!! Vous avez trouvé en {essais} coups!";
                    textRetour2.Text = $"Le nombre mystère était {mystere}";
                    lblNbEssais.Content = $"Nombre d'Essais : {essais}";
                    btnValider.IsEnabled = false;
                }
            }
        }

        private void RecommencerSaisie_Click(object sender, RoutedEventArgs e)
        {
            textRetour1.Text = $"";
            textRetour2.Text = $"Veuillez saisir un nombre";
            lblNbEssais.Content = $"Nombre d'Essais : 0";
            essais = 0;
            mystere = random.Next(1, 51);
            trouve = false;
            btnValider.IsEnabled = true;
        }
    }
}
