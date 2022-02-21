using TpCompteBancaireASPNET.Data;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text;

namespace TpCompteBancaireASPNET.Models
{
    public class ComptePayant : Compte
    {
        private decimal coutOperation;
        public decimal CoutOperation { get => coutOperation; set => coutOperation = value; }

        public ComptePayant(decimal coutOperation) 
        {
            CoutOperation = coutOperation;
        }
        public ComptePayant(decimal solde, Client client, decimal coutOperation) : base(solde, client)
        {
            CoutOperation = coutOperation;
        }

        public override bool Depot(Operation operation)
        {
            if(operation.Montant > CoutOperation)
            {
                if(base.Depot(operation))
                {
                    return base.Retrait(new Operation(CoutOperation * -1));
                }
            }
            return false;
        }

        public override bool Retrait(Operation operation)
        {
            if(Solde >= Math.Abs(operation.Montant) + CoutOperation)
            {
                if(base.Retrait(operation))
                {
                    return base.Retrait(new Operation(CoutOperation * -1));
                }
            }
            return false;
        }
        public override bool AjouterCompte()
        {
            SqlConnection connection = DataBase.Connection;
            SqlCommand command = new SqlCommand("INSERT INTO compte (solde, taux, coutOperation) OUTPUT INSERTED.ID VALUES (@Solde, @Taux, @coutOperation)", connection);
            command.Parameters.Add(new SqlParameter("@Solde", SqlDbType.Decimal) { Value = Solde });
            command.Parameters.Add(new SqlParameter("@Taux", SqlDbType.Decimal) { Value = 0 });
            command.Parameters.Add(new SqlParameter("@coutOperation", SqlDbType.Decimal) { Value = CoutOperation });
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
