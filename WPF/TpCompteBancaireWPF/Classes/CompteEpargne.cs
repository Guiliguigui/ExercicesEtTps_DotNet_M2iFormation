using TpCompteBancaireWPF.Data;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text;

namespace TpCompteBancaireWPF.Classes
{
    public class CompteEpargne : Compte
    {
        private decimal taux;
        
        public decimal Taux { get => taux; set => taux = value; }

        public CompteEpargne(decimal taux)
        {
            Taux = taux;
        }

        public CompteEpargne(decimal solde, Client client, decimal taux) : base(solde, client)
        {
            Taux = taux;
        }

        public bool CalculeInteret()
        {
            return base.Depot(new Operation(Solde * Taux / 100));
        }
        public override bool AjouterCompte()
        {
            SqlConnection connection = DataBase.Connection;
            SqlCommand command = new SqlCommand("INSERT INTO compte (solde, taux, coutOperation) OUTPUT INSERTED.ID VALUES (@Solde, @Taux, @coutOperation)", connection);
            command.Parameters.Add(new SqlParameter("@Solde", SqlDbType.Decimal) { Value = Solde });
            command.Parameters.Add(new SqlParameter("@Taux", SqlDbType.Decimal) { Value = Taux });
            command.Parameters.Add(new SqlParameter("@coutOperation", SqlDbType.Decimal) { Value = 0 });
            connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            command = new SqlCommand("INSERT INTO clientCompte (idClient, idCompte) VALUES (@IdClient, @IdCompte)", connection);
            command.Parameters.Add(new SqlParameter("@IdClient", Client.Id));
            command.Parameters.Add(new SqlParameter("@IdCompte", Id));
            int nbLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            if (nbLigne > 0)
                return true;
            else
                return false;
        }
    }
}
