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
        public void Number()
        {
            Evaluator evaluator = new Evaluator();           
            Assert.AreEqual("3", evaluator.Eval("3"));
        }

        [TestMethod]
        public void Add()
        {
            Evaluator evaluator = new Evaluator();
            Assert.AreEqual("3", evaluator.Eval(l(new[] {"+", "1", "2"})));
        }

        [TestMethod]
        public void Sub()
        {
            Evaluator evaluator = new Evaluator();            
            Assert.AreEqual("4", evaluator.Eval(l(new[] { "-", "6", "2" })));
        }

        private Queue<string> l(string[] s)
        {
            return new Queue<string>(s);
        }
    }
}
