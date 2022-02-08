using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3Pendu
{
    internal class LePendu
    {
        public int NbEssai { get; set; }
        public string Masque { get; set; }
        public string MotATrouve { get; set; }

        public LePendu()
        {
            MotATrouve = GenerateurDeMot.Generer();
            NbEssai = 0;
            GenererMasque();
        }

        public bool TestChar(char testChar)
        {
            NbEssai++;
            if (MotATrouve.Contains(testChar))
            {
                for (int i = 0; i < MotATrouve.Length; i++)
                {
                    if (testChar == MotATrouve[i])
                    {
                        StringBuilder sb = new StringBuilder(Masque);
                        sb[i] = testChar;
                        Masque = sb.ToString();
                    }
                }
            }
            return MotATrouve.Contains(testChar);
        }
        public bool TestWin()
        {
            return !Masque.Contains('*');
        }
        public void GenererMasque()
        {
            Masque = string.Concat(Enumerable.Repeat("*", MotATrouve.Length));
        }
    }
}
