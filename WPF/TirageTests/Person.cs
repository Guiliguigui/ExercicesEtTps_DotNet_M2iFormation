using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TirageTests
{
    public class Person
    {
        private readonly string title;
        private readonly string firstName;
        private readonly string lastName;

        public Person(string title, string firstName, string lastName)
        {
            this.title = title;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string Title => title;

        public string FirstName => firstName;

        public string LastName => lastName;

        public override string ToString()
        {
            return $"{{{nameof(Title)}={Title}, {nameof(FirstName)}={FirstName}, {nameof(LastName)}={LastName}}}";
        }
    }
}
