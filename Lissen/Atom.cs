using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lissen
{
    public class Atom : Symbol
    {
        private string AsString;

        public static Atom s(string s)
        {
            Atom a = new Atom();
            a.AsString = s;
            return a;
        }

        public string ToString()
        {
            return this.AsString;
        }
    }
}
