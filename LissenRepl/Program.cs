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

            Parser parser = new Parser();

            while(true)
            {
                Console.Write("> ");
                string userInput = Console.ReadLine();

                try
                {
                    foreach (Sexpr sexpr in parser.Parse(userInput))
                    {
                        string result = sexpr.Eval(globalEnv).ToString();
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
