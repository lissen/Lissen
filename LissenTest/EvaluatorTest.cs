using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lissen;
using System.Collections.Generic;

namespace LissenTest
{
    [TestClass]
    public class EvaluatorTest : SexprHelpers
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
            Assert.AreEqual(nil, eval(nil));
        }

        [TestMethod]
        public void Number()
        {
            Assert.AreEqual(a("3"), eval(a("3")));
        }        

        [TestMethod]
        public void Add()
        {
            Assert.AreEqual(a("3"), eval(l(new[] { "+", "1", "2" })));
        }
       
        [TestMethod]
        public void Sub()
        {
            Assert.AreEqual(a("4"), eval(l(new[] { "-", "6", "2" })));
        }

        [TestMethod]
        public void AddNestedPairs()
        {
            Assert.AreEqual(a("17"), eval(l(new Sexpr[] {a("+"), l(new[] { "+", "6", "2" }), a("9")})));
        }

        [TestMethod]
        public void SubNestedPairs()
        {
            Assert.AreEqual(a("5"), eval(l(new Sexpr[] { a("-"), l(new[] { "-", "10", "2" }), a("3") })));
        }

        [TestMethod]
        public void Quote()
        {
            List quoted = l(new[] { "-", "10", "2" });
            Assert.AreEqual(quoted, eval(quote(quoted)));
        }

        [TestMethod]
        public void DefineWithAtom()
        {            
            define("x", a("3"));       
            Assert.IsTrue(env.IsDefined(a("x")));
            Assert.AreEqual(a("3"), env.Find(a("x")));
            Assert.AreEqual(a("3"), e.Eval(a("x"), env));
        }

        [TestMethod]
        public void DefineWithEvaluatedList()
        {
            define("x", l(new[] { "-", "10", "2" }));
            Assert.IsTrue(env.IsDefined(a("x")));
            Assert.AreEqual(a("8"), env.Find(a("x")));
        }

        [TestMethod]
        public void DefineQuotedList()
        {
            List quoted = l(new[] { "-", "10", "2" });
            define("x", quote(l(new[] { "-", "10", "2" })));
            Assert.AreEqual(quoted, env.Find(a("x")));
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
        private Sexpr eval(Sexpr s)
        {
            return e.Eval(s, env);
        }

        private Sexpr define(string variableName, Sexpr value)
        {
            return eval(l(new Sexpr[] { a("define"), a(variableName), value }));
        }
        #endregion
    }
}
