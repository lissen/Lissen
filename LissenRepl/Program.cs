using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lissen;

namespace LissenRepl
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lissen Lisp");
            Console.WriteLine("");
            Console.WriteLine("<ctrl>-C to exit.");

            Evaluator evaluator = new Evaluator();
            Parser parser = new Parser();

            while(true)
            {
                Console.Write(">");
                string userInput = Console.ReadLine();

                string result;
                try
                {
                    result = evaluator.Eval(parser.Parse(userInput)).ToString();
                }
                catch(Exception e)
                {
                    result = "Error: " + e.Message;
                }
                
                Console.WriteLine(result);
            }            
        }
    }
}
