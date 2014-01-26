using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lissen
{
    public class Lambda : Function
    {
        private List vars;
        private List form;

        public Lambda(List vars, List form)
        {
            this.vars = vars;
            this.form = form;
        }
    }
}
