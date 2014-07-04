using System;
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

            var globalEnv = new VariablesEnvironment();

            var parser = new Parser();

            while(true)
            {
                Console.Write("> ");
                var userInput = Console.ReadLine();

                try
                {
                    foreach (var sexpr in parser.Parse(userInput))
                    {
                        var result = sexpr.Eval(globalEnv).ToString();
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
