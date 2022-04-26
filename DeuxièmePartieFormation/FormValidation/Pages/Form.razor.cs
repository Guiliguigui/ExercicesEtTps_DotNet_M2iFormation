using FormValidation.Models;
using Microsoft.AspNetCore.Components;

namespace FormValidation.Pages
{
    public class FormBase : ComponentBase
    {
        protected Person Person { get; set; } = new Person() { BirthDate = System.DateTime.Now.AddYears(-18) };
        protected bool ShowResult { get; set; } = false;

        protected void Submit()
        {
            ShowResult = true;
        }

    }
}
