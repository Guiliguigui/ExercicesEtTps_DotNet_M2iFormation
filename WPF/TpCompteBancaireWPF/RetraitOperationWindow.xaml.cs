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
    /// Logique d'interaction pour RetraitOperationWindow.xaml
    /// </summary>
    public partial class RetraitOperationWindow : Window
    {
        private Compte compte = null;

        public RetraitOperationWindow()
        {
            InitializeComponent();
        }
        public RetraitOperationWindow(Compte compte) : this()
        {
            this.compte = compte;
            lblIdCompte.Content = $"Id Compte : {compte.Id}";
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            if (compte != null && decimal.TryParse(TextBoxMontant.Text, out decimal montant))
            {
                Operation operation = new Operation(montant * -1);
                if (compte.Retrait(operation))
                {
                    MessageBox.Show($"Le retrait de {montant} € a été effectué");
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
