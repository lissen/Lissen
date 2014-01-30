using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lissen;

namespace LissenTest
{
    [TestClass]
    public class SampleProgramsTest : SexprHelpers 
    {
        [TestMethod]
        public void DefineVariable()
        {
            var program = @"
                (define x 3)
                (+ x 2)";
            Assert.AreEqual(a("5"), evalProgram(program));                    
        }

        [TestMethod]
        public void EvalLambda()
        {
            var program = @"
                (define x 4)
                ((lambda (x) (+ x 3)) 2)";
            Assert.AreEqual(a("5"), evalProgram(program));                    
        }

        [TestMethod]
        public void DefineLambda()
        {
            var program = @"
                (define x 2)
                (define add (lambda (x) (+ x 7)))
                (add 2)";
            Assert.AreEqual(a("9"), evalProgram(program));
        }

        [TestMethod]
        public void If()
        {
            var program = @"
                (define x 2)
                (if (= 2 2) good notgood)";
            Assert.AreEqual(a("good"), evalProgram(program));
        }

        [TestMethod]
        public void Recursive1()
        {
            var program = @"
                        (define rec 
                            (lambda (x) 
                                (if (= x 0) end 
                                    (rec (- x 1))
                                 )))
                        (rec 3)";
            Assert.AreEqual(a("end"), evalProgram(program));
        }

        [TestMethod]
        public void Recursive2()
        {
            var program = @"
                (define rec 
                    (lambda (x acc) 
                        (if (= x 0) 
                            acc 
                            (rec (- x 1) (* acc 2))
                         )))
                (rec 3 1)";
            Assert.AreEqual(a("8"), evalProgram(program));
        }

        [TestMethod]
        public void DefineFunction()
        {
            var program = @"
                (define (add x y)
                    (+ x y)) 
                (add 3 1)";
            Assert.AreEqual(a("4"), evalProgram(program));
        }

        [TestMethod]
        public void DefineRecursiveFunction()
        {
            var program = @"
                (define (fib n)
                    (if (= n 0) 1
                    (if (= n 1) 1                        
                        (+ (fib (- n 1)) (fib (- n 2)))
                    )))
                (fib 8)";
            Assert.AreEqual(a("34"), evalProgram(program));
        }

        [TestMethod]
        public void DefineRecursiveFib()
        {
            var program = @"
                (define (fib n)
                    (cond 
                        ((= n 0) 1)
                        ((= n 1) 1)
                        (else (+ (fib (- n 1)) (fib (- n 2))))
                    ))
                (fib 8)";
            Assert.AreEqual(a("34"), evalProgram(program));
        }

        private Sexpr evalProgram(string s)
        {
            Parser parser = new Parser();
            var env = new VariablesEnvironment();

            Sexpr lastOne = null;
            foreach (Sexpr sexpr in parser.Parse(s))
            {
                lastOne = sexpr.Eval(env);
            }

            return lastOne;
        }
    }
}
