using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lissen
{
    public class Evaluator
    {

        public string Eval(string s)
        {
            return s;
        }

        public string Eval(Queue<string> list)
        {
            string op = list.Dequeue();

            switch (op)
            {
                case "+": { 
                    var first = Convert.ToInt32(Eval(list.Dequeue()));
                    var second= Convert.ToInt32(Eval(list.Dequeue()));
                    int result = first + second;
                    return result.ToString();
                }

                case "-": {
                    var first = Convert.ToInt32(Eval(list.Dequeue()));
                    var second = Convert.ToInt32(Eval(list.Dequeue()));
                    int result = first - second;
                    return result.ToString();
                }
            }

            throw new Exception("Unable to evaluate operation " + op);
        }
    }
}
