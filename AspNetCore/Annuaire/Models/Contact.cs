namespace Annuaire.Models
{
    public class Contact
    {
        private int id;
        private string firstName;
        private string lastName;
        private string phone;

        public Contact()
        {

        }

        public Contact(string firstName, string lastName, string phone)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phone = phone;
        }

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Phone { get => phone; set => phone = value; }
    }
}
