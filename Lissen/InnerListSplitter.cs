using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lissen
{
    public struct InnerSplitted
    {
        public string before;
        public string inner;
        public string after;
    }

    public class InnerListSplitter
    {
        public static InnerSplitted split(string s)
        {
            int closing = s.IndexOf(')');

            if (closing == -1) return new InnerSplitted
            {
                before = "",
                inner = "",
                after = s
            };

            int opening = 0;
            for (int i = closing; i > 0 && opening == 0; i--)
            {
                if (s[i] == '(') opening = i;
            }

            return new InnerSplitted
            {
                before = s.Remove(opening),
                inner = s.Substring(opening, closing-opening+1),
                after = s.Substring(closing+1)
            };
        }
    }
}
