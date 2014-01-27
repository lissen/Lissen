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

            VariablesEnvironment globalEnv = new VariablesEnvironment();

            Evaluator evaluator = new Evaluator();
            Parser parser = new Parser();

            while(true)
            {
                Console.Write("> ");
                string userInput = Console.ReadLine();

                string result;
                try
                {
                    foreach (Sexpr sexpr in parser.Parse(userInput))
                    {
                        result = evaluator.Eval(sexpr, globalEnv).ToString();
                        Console.WriteLine(result);
                    }                    
                }
                catch(Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }            
        }
    }
}
