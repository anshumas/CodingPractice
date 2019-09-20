using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCoding
{
    public class Chapter01
    {
        public static bool IsUnique(string s)
        {
            if (s.Length > 26)
                return false;
            char[] charArray = s.ToCharArray();
            Array.Sort(charArray);
            char prev=new char();
            foreach (var item in charArray)
            {
                if (item == prev)
                    return false;
                prev = item;
            }  
            return true;
        }
    }
}
