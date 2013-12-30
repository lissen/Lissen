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

        }

        [TestMethod]
        public void Add()
        {
            Evaluator evaluator = new Evaluator();
            Queue<string> list = new Queue<string>(new string[] { "+", "1", "2" });
            Assert.AreEqual("3", evaluator.Eval(list));
        }

        [TestMethod]
        public void Sub()
        {
            Evaluator evaluator = new Evaluator();
            Queue<string> list = new Queue<string>(new string[] { "-", "6", "2" });
            Assert.AreEqual("4", evaluator.Eval(list));
        }
    }
}
