using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lissen;
using System.Collections.Generic;

namespace LissenTest
{
    [TestClass]
    public class EvaluatorTest
    {
        private Nil nil = new Nil();

        [TestMethod]
        public void Empty()
        {
            Evaluator e = new Evaluator();
            Assert.AreEqual(nil, e.Eval(nil));
        }

        [TestMethod]
        public void Number()
        {
            Evaluator e = new Evaluator();           
            Assert.AreEqual(Atom.s("3"), e.Eval(Atom.s("3")));
        }        

        [TestMethod]
        public void Add()
        {
            Evaluator e = new Evaluator();
            Assert.AreEqual(Atom.s("3"), e.Eval(l(new[] { "+", "1", "2" })));
        }
       
        [TestMethod]
        public void Sub()
        {
            Evaluator e = new Evaluator();
            Assert.AreEqual(Atom.s("4"), e.Eval(l(new[] { "-", "6", "2" })));
        }

        [TestMethod]
        public void AddNestedPairs()
        {
            Evaluator e = new Evaluator();
            Assert.AreEqual(Atom.s("17"), e.Eval(l(new Symbol[] {Atom.s("+"), l(new[] { "+", "6", "2" }), Atom.s("9")})));
        }

        [TestMethod]
        public void SubNestedPairs()
        {
            Evaluator e = new Evaluator();
            Assert.AreEqual(Atom.s("5"), e.Eval(l(new Symbol[] { Atom.s("-"), l(new[] { "-", "10", "2" }), Atom.s("3") })));
        }
       
        [TestMethod]
        public void ThrowExceptionWhenCannotEvaluate()
        {
            try
            {
                Evaluator e = new Evaluator();
                e.Eval(l(new[] { "dummystuff", "1", "2" }));
                Assert.Fail("Should have raised an exception");
            }
            catch (Exception ex)  {
                Assert.IsTrue(ex.Message.Contains("Unable to evaluate operation"));
            }
        }
              
        private List l(string[] stringList)
        {
            List list = new List();
            foreach(string s in stringList)
            {
                list.Add(Atom.s(s));
            }
            return list;
        }

        private List l(Symbol[] symList)
        {
            List list = new List();
            foreach (Symbol s in symList)
            {
                list.Add(s);
            }
            return list;
        }
    }
}
