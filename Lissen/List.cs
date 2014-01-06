using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lissen
{
    public class List : List<Symbol>, Symbol
    {
        public Symbol Car()
        {
            return this[0];
        }

        public Symbol Cdr()
        {
            return this[1];
        }

        public Symbol Cadr()
        {
            return this[2];
        }

        public override string ToString()
        {
            return "(" + String.Join(" ", this) + ")";
        }

        public override bool Equals(object other)
        {
            List otherList = other as List;
            if (otherList == null) return false;
            if (this.Count != otherList.Count) return false;

            Enumerator itThis = this.GetEnumerator();
            Enumerator itOther = otherList.GetEnumerator();

            while (itThis.MoveNext())
            {
                itOther.MoveNext();

                if (!itThis.Current.Equals(itOther.Current)) return false;
            }
            return true;
        }
    }
}
