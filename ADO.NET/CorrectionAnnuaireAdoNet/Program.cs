using CorrectionAnnuaireAdoNet.Classes;
using System;

namespace CorrectionAnnuaireAdoNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Contact contact = new Contact();
            contact.FirstName = "ihab";
            contact.LastName = "abadi";
            contact.Phone = "060606060";
            contact.Email = "ihab@utopios.net";
            if(contact.Save())
            {
                Console.WriteLine(contact.Id);
            }
        }
    }
}
