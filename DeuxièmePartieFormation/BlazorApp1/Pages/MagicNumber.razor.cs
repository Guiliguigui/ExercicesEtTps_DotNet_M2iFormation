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
        protected string LifesString => Lifes > 0 ? new string('❤', Lifes) : "";

        [Inject]
        protected NavigationManager _navigationManager { get; set; }
        protected MagicNumberBase()
        {
            Random rand = new Random();
            MagicNumber = rand.Next(max + 1);
        }

        protected void TestNumber()
        {
            if (MagicNumber == Number)
            {
                _navigationManager.NavigateTo("/MagicNumber/Result/true");
                return;
            }
            Lifes--;
            if (Lifes == 0)
            {
                _navigationManager.NavigateTo("/MagicNumber/Result/false");
            }
        }
    }
}
