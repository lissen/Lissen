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

//        [TestMethod]
//        public void Recursive()
//        {
//            var program = @"
//                (define rec 
//                    (lambda (x acc) 
//                        (if (= x 0) 
//                            acc 
//                            (rec (- x 1) (* acc 2))
//                         )))
//                (rec 3 1)";
//            Assert.AreEqual(a("8"), evalProgram(program));
//        }

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
