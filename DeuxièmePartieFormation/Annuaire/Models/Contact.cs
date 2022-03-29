using Annuaire.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Annuaire.Models
{
    public class Contact
    {
        private string email;
        private string phone;
        private string lastName;
        private string firstName;

        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]{1}[a-zA-Z\séèë\-_]*$", ErrorMessage = "Invalid email FirstName")]
        public string FirstName { get => firstName; set => firstName = value; }
        [Required]
        [RegularExpression(@"^[A-Z]{1}[a-zA-Z\séèë\-_]*$", ErrorMessage = "Invalid LastName")]
        public string LastName { get => lastName; set => lastName = value; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9\.\-_]+)@([a-zA-Z0-9\-_]+)(\.)?([a-zA-Z0-9\-_]+)?(\.){1}([a-zA-Z]{2,11})$", ErrorMessage = "Invalid Email Address")]
        public string Email { get => email; set => email = value; }
        [Required]
        [RegularExpression(@"^([0|\+33|33]+)(\.|\-|\s)?([1-9]{1})((\.|\-|\s)?[0-9]{2}){4}$", ErrorMessage = "Invalid Phone Number")]
        public string Phone { get => phone;  set => phone = Tools.FormatPhone(value); }
    }
}
