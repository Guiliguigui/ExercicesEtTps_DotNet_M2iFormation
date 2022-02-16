using TpCompteBancaireWPF.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace TpCompteBancaireWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static ObservableCollection<Operation> operations;
        private static Compte compte = null;
        public MainWindow()
        {
            InitializeComponent();
            operations = new ObservableCollection<Operation>();
            ListeBoxOperations.ItemsSource = operations;
        }

        private void RechercherCompte_Click(object sender, RoutedEventArgs e)
        {
            LoadCompte();
        }

        private void EffectuerDepot_Click(object sender, RoutedEventArgs e)
        {
            if(compte != null)
            {
                DepotOperationWindow depotOperation = new DepotOperationWindow(compte);
                depotOperation.ShowDialog();
                LoadCompte();
            }
        }

        private void EffectuerRetrait_Click(object sender, RoutedEventArgs e)
        {
            if (compte != null)
            {
                RetraitOperationWindow retraitOperation = new RetraitOperationWindow(compte);
                retraitOperation.ShowDialog();
                LoadCompte();
            }
        }

        private void CalculerInterets_Click(object sender, RoutedEventArgs e)
        {
            if (compte != null && compte is CompteEpargne compteEpargne)
            {
                if (compteEpargne.CalculeInteret())
                {
                    LoadCompte();
                }
            }
        }

        private void MenuCreation_Click(object sender, RoutedEventArgs e)
        {
            AjouterCompteWindow ajouterCompteWindow = new AjouterCompteWindow();
            ajouterCompteWindow.ShowDialog();
        }

        public void LoadCompte()
        {
            operations.Clear();
            bool correctEntry = int.TryParse(TextBoxCompte.Text, out int idCompte);
            if (correctEntry)
                compte = Compte.RechercherCompte(idCompte);
            if (correctEntry && compte != null)
            {
                lblClient.Content = $"Nom : {compte.Client.Nom}  Prénom : {compte.Client.Prenom}  Téléphone : {compte.Client.Telephone}";
                lblIdCompte.Content = $"Id du compte : {compte.Id}";
                lblSoldeCompte.Content = $"Solde en euros : {compte.Solde}";
                if (compte is CompteEpargne compteEpargne)
                {
                    lblTauxInterets.Content = $"Taux d'Intérêts : {compteEpargne.Taux}%";
                }
                else
                    lblTauxInterets.Content = $"Taux d'Intérêts : 0%";
                foreach (Operation operation in compte.Operations)
                {
                    operations.Add(operation);
                }
            }
            else
            {
                lblClient.Content = $"Nom :   Prénom :   Téléphone : ";
                lblIdCompte.Content = $"Id du compte : ";
                lblSoldeCompte.Content = $"Solde en euros : ";
                lblTauxInterets.Content = $"Taux d'Intérêts : 0%";
                operations.Clear();
            }
        }
    }
}
