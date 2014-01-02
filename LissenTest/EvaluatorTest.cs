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
            Assert.AreEqual(null, e.Eval(null as Atom));
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
        
        private Pair l(string[] list)
        {
            if (list.Length == 0) return null as Pair;

            Atom a = Atom.s(list[0]);
            if (list.Length == 1) return Pair.Cons(a, null);

            string[] cdr = new string[list.Length-1];
            Array.Copy(list, 1, cdr, 0, list.Length-1);
            return Pair.Cons(a, l(cdr));
        }

        private Pair l(Symbol[] list)
        {
            if (list.Length == 0) return null as Pair;

            Symbol a = list[0];
            if (list.Length == 1) return Pair.Cons(a, null);

            Symbol[] cdr = new Symbol[list.Length - 1];
            Array.Copy(list, 1, cdr, 0, list.Length - 1);
            return Pair.Cons(a, l(cdr));
        }
    }
}
