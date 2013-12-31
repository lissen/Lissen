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
            if (list.Count == 0) return "";

            string op = list.Dequeue();

            switch (op)
            {
                case "+": { 
                    int first = Convert.ToInt32(Eval(list.Dequeue()));
                    int second= Convert.ToInt32(Eval(list.Dequeue()));
                    int result = first + second;
                    return result.ToString();
                }

                case "-": {
                    int first = Convert.ToInt32(Eval(list.Dequeue()));
                    int second = Convert.ToInt32(Eval(list.Dequeue()));
                    int result = first - second;
                    return result.ToString();
                }
            }

            throw new Exception("Unable to evaluate operation " + op);
        }
    }
}
