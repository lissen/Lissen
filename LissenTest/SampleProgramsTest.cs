using Lissen;
using NFluent;
using NUnit.Framework;

namespace LissenTest
{
    public class SampleProgramsTest : SexprHelpers 
    {
        [Test]
        public void DefineVariable()
        {
            const string program = @"
                (define x 3)
                (+ x 2)";
            Check.That(evalProgram(program)).Equals(a("5"));
        }

        [Test]
        public void EvalLambda()
        {
            const string program = @"
                (define x 4)
                ((lambda (x) (+ x 3)) 2)";
            Check.That(evalProgram(program)).Equals(a("5"));
        }

        [Test]
        public void DefineLambda()
        {
            const string program = @"
                (define x 2)
                (define add (lambda (x) (+ x 7)))
                (add 2)";
            Check.That(evalProgram(program)).Equals(a("9"));
        }

        [Test]
        public void If()
        {
            const string program = @"
                (define x 2)
                (if (= 2 2) good notgood)";
            Check.That(evalProgram(program)).Equals(a("good"));
        }

        [Test]
        public void Recursive1()
        {
            const string program = @"
                        (define rec 
                            (lambda (x) 
                                (if (= x 0) end 
                                    (rec (- x 1))
                                 )))
                        (rec 3)";
            Check.That(evalProgram(program)).Equals(a("end"));
        }

        [Test]
        public void Recursive2()
        {
            const string program = @"
                (define rec 
                    (lambda (x acc) 
                        (if (= x 0) 
                            acc 
                            (rec (- x 1) (* acc 2))
                         )))
                (rec 3 1)";
            Check.That(evalProgram(program)).Equals(a("8"));
        }

        [Test]
        public void DefineFunction()
        {
            const string program = @"
                (define (add x y)
                    (+ x y)) 
                (add 3 1)";
            Check.That(evalProgram(program)).Equals(a("4"));
        }

        [Test]
        public void DefineRecursiveFunction()
        {
            const string program = @"
                (define (fib n)
                    (if (= n 0) 1
                    (if (= n 1) 1                        
                        (+ (fib (- n 1)) (fib (- n 2)))
                    )))
                (fib 8)";
            Check.That(evalProgram(program)).Equals(a("34"));
        }

        [Test]
        public void DefineRecursiveFib()
        {
            const string program = @"
                (define (fib n)
                    (cond 
                        ((= n 0) 1)
                        ((= n 1) 1)
                        (else (+ (fib (- n 1)) (fib (- n 2))))
                    ))
                (fib 8)";
            Check.That(evalProgram(program)).Equals(a("34"));
        }

        private Sexpr evalProgram(string s)
        {
            var parser = new Parser();
            var env = new VariablesEnvironment();

            Sexpr lastOne = null;
            foreach (var sexpr in parser.Parse(s))
            {
                lastOne = sexpr.Eval(env);
            }

            return lastOne;
        }
    }
}
