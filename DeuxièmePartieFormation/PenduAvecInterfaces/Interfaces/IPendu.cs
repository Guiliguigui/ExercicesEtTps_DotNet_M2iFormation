using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenduAvecInterfaces.Interfaces
{
    public interface IPendu
    {
        public string Masque { get; }
        public string MotAtrouve { get; }
        public int NbEssai { get; }

        public bool TestChar(char c);
        public bool TestWin();
        public void GenererMasque(IGenerateurDeMot generateur);
    }
}
