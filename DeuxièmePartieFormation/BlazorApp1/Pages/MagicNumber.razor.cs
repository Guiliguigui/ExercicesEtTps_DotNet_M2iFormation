using Microsoft.AspNetCore.Components;
using System;

namespace BlazorApp1.Pages
{
    public class MagicNumberBase : ComponentBase
    {
        protected const int max = 20;
        protected int MagicNumber { get; set; }
        protected int Number { get; set; }
        protected int Lifes { get; set; } = 5;
        protected string LifesString => new string('❤', Lifes);

        [Inject]
        protected NavigationManager NavigationManager { get; set; }
        protected MagicNumberBase()
        {
            Random rand = new Random();
            MagicNumber = rand.Next(max + 1);
        }

        protected void TestNumber()
        {
            if (MagicNumber == Number)
            {
                NavigationManager.NavigateTo("/MagicNumber/Result/true");
                return;
            }
            Lifes--;
            if (Lifes == 0)
            {
                NavigationManager.NavigateTo("/MagicNumber/Result/false");
            }
        }
    }
}
