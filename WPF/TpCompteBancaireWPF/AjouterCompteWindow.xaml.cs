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
using TpCompteBancaireWPF.Classes;

namespace TpCompteBancaireWPF
{
    /// <summary>
    /// Logique d'interaction pour AjouterCompteWindow.xaml
    /// </summary>
    public partial class AjouterCompteWindow : Window
    {
        private Client client = null;
        private Compte compte = null;

        public AjouterCompteWindow()
        {
            InitializeComponent();
        }

        private void AjouterClient_Click(object sender, RoutedEventArgs e)
        {
            if(TextBoxNom.Text != "" && TextBoxPrenom.Text != "" && TextBoxTelephone.Text != "")
            {
                client = new Client(TextBoxNom.Text, TextBoxPrenom.Text, TextBoxTelephone.Text);
                client.Id = client.Add();
                if(client.Id != 0)
                    LabelIdClient.Content = $"Id Client : {client.Id}";
            }
        }

        private void CreerCompte_Click(object sender, RoutedEventArgs e)
        {
            if (client != null && decimal.TryParse(TextBoxSolde.Text, out decimal solde))
            {
                if(CompteNormalRdBtn.IsChecked == true)
                {
                    compte = new Compte(solde, client);
                }
                else if(CompteEpargneRdBtn.IsChecked == true && decimal.TryParse(TextBoxInterets.Text, out decimal taux))
                {
                    compte = new CompteEpargne(solde, client, taux);
                }
                else if(ComptePremiumRdBtn.IsChecked == true && decimal.TryParse(TextBoxCoutOperation.Text, out decimal cout))
                {
                    compte = new ComptePayant(solde, client, cout);
                }
                if (compte != null && compte.AjouterCompte())
                {
                    MessageBox.Show($"le compte a été créé avec l'Id : {compte.Id}");
                    this.Close();
                }
            }
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
