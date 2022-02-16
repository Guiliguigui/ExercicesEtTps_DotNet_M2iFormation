using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TpCompteBancaireWPF.Classes
{
    public class Tools
    {
        public static bool IsName(string name)
        {
            string pattern = @"^([A-Z]{1})([a-zA-Z\s\-]*)$";
            return Regex.IsMatch(name, pattern);
        }
        public static bool IsPhone(string phone)
        {
            string pattern = @"^([+33|0]+)(\s|\.|\-)?([1-9]{1})(\.|\s|\-)?([0-9]{2}(\.|\s|\-)?){4}$";
            return Regex.IsMatch(phone, pattern);
        }        
    }
}
