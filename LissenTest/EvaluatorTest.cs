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
        private Evaluator e;
        private VariablesEnvironment env;

        [TestInitialize]
        public void Setup()
        {
            env = new VariablesEnvironment();
            e = new Evaluator();
        }

        [TestMethod]
        public void Empty()
        {
            Evaluator e = new Evaluator();
            Assert.AreEqual(nil, eval(nil));
        }

        [TestMethod]
        public void Number()
        {
            Evaluator e = new Evaluator();           
            Assert.AreEqual(a("3"), eval(a("3")));
        }        

        [TestMethod]
        public void Add()
        {
            Evaluator e = new Evaluator();
            Assert.AreEqual(a("3"), eval(l(new[] { "+", "1", "2" })));
        }
       
        [TestMethod]
        public void Sub()
        {
            Evaluator e = new Evaluator();
            Assert.AreEqual(a("4"), eval(l(new[] { "-", "6", "2" })));
        }

        [TestMethod]
        public void AddNestedPairs()
        {
            Evaluator e = new Evaluator();
            Assert.AreEqual(a("17"), eval(l(new Symbol[] {a("+"), l(new[] { "+", "6", "2" }), a("9")})));
        }

        [TestMethod]
        public void SubNestedPairs()
        {
            Evaluator e = new Evaluator();
            Assert.AreEqual(a("5"), eval(l(new Symbol[] { a("-"), l(new[] { "-", "10", "2" }), a("3") })));
        }

        [TestMethod]
        public void Quote()
        {
            Evaluator e = new Evaluator();
            List quoted = l(new[] { "-", "10", "2" });
            Assert.AreEqual(quoted, eval(l(new Symbol[] { a("quote"), quoted })));
        }

        [TestMethod]
        public void DefineWithAtom()
        {
            VariablesEnvironment env = new VariablesEnvironment();
            Evaluator e = new Evaluator();            
            e.Eval(l(new [] { "define", "x", "3" }), env);
            Assert.IsTrue(env.IsDefined(a("x")));
            Assert.AreEqual(a("3"), env.Find(a("x")));
            Assert.AreEqual(a("3"), e.Eval(a("x"), env));
        }

        [TestMethod]
        public void DefineWithEvaluatedList()
        {
            VariablesEnvironment env = new VariablesEnvironment();
            Evaluator e = new Evaluator();
            e.Eval(l(new Symbol[] { a("define"), a("x"), l(new[] { "-", "10", "2" }) }), env);
            Assert.IsTrue(env.IsDefined(a("x")));
            Assert.AreEqual(a("8"), env.Find(a("x")));
        }

        [TestMethod]
        public void DefineQuotedList()
        {
            e.Eval(l(new Symbol[] { a("define"), a("x"), l(new[] { "-", "10", "2" }) }), env);
            Assert.IsTrue(env.IsDefined(a("x")));
            Assert.AreEqual(a("8"), env.Find(a("x")));
        }

        [TestMethod]
        public void ThrowExceptionWhenCannotEvaluate()
        {
            try
            {
                Evaluator e = new Evaluator();
                eval(l(new[] { "dummystuff", "1", "2" }));
                Assert.Fail("Should have raised an exception");
            }
            catch (Exception ex)  {
                Assert.IsTrue(ex.Message.Contains("Unable to evaluate operation"));
            }
        }

        #region Helpers

        private Symbol eval(Symbol s)
        {
            return e.Eval(s, env);
        }

        private Atom a(string s)
        {
            return Atom.s(s);
        }
              
        private List l(string[] stringList)
        {
            List list = new List();
            foreach(string s in stringList)
            {
                list.Add(a(s));
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
        #endregion
    }
}
