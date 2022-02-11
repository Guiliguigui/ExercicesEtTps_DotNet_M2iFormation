using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpCompteBancaireHeritage.DAO;
using TpCompteBancaireHeritage.Tools;

namespace TpCompteBancaireHeritage.Classes
{
    public class Compte 
    {
        private int id;
        private decimal solde;
        private Client client;
        private List<Operation> operations;
        private static int counter = 0;
        private CompteDAO compteDAO;
        private OperationDAO operationDAO;

        public Compte()
        {
            //id = ++counter;
            Operations = new List<Operation>();
        }

        public Compte(decimal solde, Client client) : this()
        {            
            Solde = solde;
            Client = client;            
        }

        public int Id { get => id; set => id = value; }
        public decimal Solde { get => solde; set => solde = value; }
        internal Client Client { get => client; set => client = value; }
        internal List<Operation> Operations { get => operations; set => operations = value; }
        public static int Counter { get => counter; }

        public virtual bool Depot(Operation operation)
        {
            compteDAO = new CompteDAO();
            operationDAO = new OperationDAO();
            if (operation.Montant > 0)
            {
                if(operationDAO.Save(operation, Id))
                {
                    Operations.Add(operation);
                    Solde += operation.Montant;
                    return compteDAO.Update(this);
                }               
            }
            return false;    
        }

        public virtual bool Retrait(Operation operation)
        {
            compteDAO = new CompteDAO();
            operationDAO = new OperationDAO();
            if (operation.Montant < 0 && Solde >= Math.Abs(operation.Montant))
            {
                if (operationDAO.Save(operation, Id))
                {
                    Operations.Add(operation);
                    Solde += operation.Montant;
                    return compteDAO.Update(this);
                }
            }
            return false;
        }

        public virtual bool AjouterCompte(Bank bank)
        {            
            return  bank.AjouterCompte(this);
        }
        
        public static Compte RechercherCompte(Bank bank,int id)
        {
            return bank.RechercherCompte(id);
        }
        public override string ToString()
        {
            string result = $"Client : {Client}\n";
            result += $"\n\t\t\t\t\t\tSolde : {Solde} Euros";
            result += $"\n------------------- Operations -------------------\n";
            Operations.ForEach(o =>
            {
                result += $"{o}\n";
            });
            result += $"--------------------------------------------------\n";

            return result;
        }
        //public bool Save()
        //{
        //    request = "INSERT INTO compte (solde, client_id) OUTPUT INSERTED.ID values (@solde, @client_id)";
        //    connection = DataBase.Connection;
        //    command = new SqlCommand(request, connection);
        //    command.Parameters.Add(new SqlParameter("@solde", Solde));
        //    command.Parameters.Add(new SqlParameter("@client_id", Client.Id));
        //    connection.Open();
        //    Id = (int)command.ExecuteScalar();
        //    command.Dispose();
        //    connection.Close();
        //    return Id > 0;
        //}
        //public bool Update()
        //{
        //    //Mise à jour du solde
        //    request = "UPDATE compte set solde=@solde where id=@id";
        //    connection = DataBase.Connection;
        //    command = new SqlCommand(request, connection);
        //    command.Parameters.Add(new SqlParameter("@solde", Solde));
        //    command.Parameters.Add(new SqlParameter("@id", Id));
        //    connection.Open();
        //    int nbRow = command.ExecuteNonQuery();
        //    command.Dispose();
        //    connection.Close();
        //    return nbRow == 1;
        //}

        //public static Compte GetCompteById(int id)
        //{
        //    Compte compte = null;
        //    int clientId = 0;
        //    request = "SELECT solde, client_id from compte where id = @id";
        //    connection = DataBase.Connection;
        //    command = new SqlCommand(request, connection);
        //    command.Parameters.Add(new SqlParameter("@id", id));
        //    connection.Open();
        //    reader = command.ExecuteReader();
        //    if (reader.Read())
        //    {
        //        compte = new Compte()
        //        {
        //            Solde = reader.GetDecimal(0),
        //            Id = id
        //        };
        //        clientId = reader.GetInt32(1);
        //    }
        //    reader.Close();
        //    command.Dispose();
        //    if(compte != null)
        //    {
        //        compte.Client = Client.GetClientById(clientId);
        //        compte.Operations = Operation.GetOperations(compte.Id);
        //    }
        //    return compte;
        //}
    }
}
