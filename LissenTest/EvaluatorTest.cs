using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lissen;
using System.Collections.Generic;

namespace LissenTest
{
    [TestClass]
    public class EvaluatorTest
    {
        [TestMethod]
        public void Empty()
        {
            Evaluator e = new Evaluator();
            Assert.AreEqual("", e.Eval(l(new string[] {})));
        }

        [TestMethod]
        public void Number()
        {
            Evaluator e = new Evaluator();           
            Assert.AreEqual("3", e.Eval("3"));
        }

        [TestMethod]
        public void Add()
        {
            Evaluator e = new Evaluator();
            Assert.AreEqual("3", e.Eval(l(new[] {"+", "1", "2"})));
        }

        [TestMethod]
        public void Sub()
        {
            Evaluator e = new Evaluator();            
            Assert.AreEqual("4", e.Eval(l(new[] { "-", "6", "2" })));
        }

        [TestMethod]
        public void ThrowExceptionWhenCannotEvaluate()
        {
            try
            {
                Evaluator e = new Evaluator();
                e.Eval(l(new[] { "dummystuff"}));
                Assert.Fail("Should have raised an exception");
            }
            catch (Exception ex)  {
                Assert.IsTrue(ex.Message.Contains("Unable to evaluate operation"));
            }
        }

        private Queue<string> l(string[] s)
        {
            return new Queue<string>(s);
        }
    }
}
