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
        public void Lambda()
        {
            var program = @"
                ((lambda ( + 2 3))
                2)";
            Assert.AreEqual(a("5"), evalProgram(program));                    
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
