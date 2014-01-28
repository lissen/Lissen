using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lissen;

namespace LissenTest
{
    [TestClass]
    public class ListTest : SexprHelpers
    {
        private List abc;
        private VariablesEnvironment env;

        [TestInitialize]
        public void SetUp()
        {
            abc = l(new[] { "a", "b", "c" });
            env = new VariablesEnvironment();
        }

        [TestMethod]
        public void Car()
        {
            Assert.AreEqual(a("a"), abc.Car());
        }

        [TestMethod]
        public void Cdr()
        {
            Assert.AreEqual(l(new[] { "b", "c" }), abc.Cdr());
        }

        [TestMethod]
        public void Cadr()
        {
            Assert.AreEqual(a("b"), abc.Cadr());
        }

        [TestMethod]
        public void Caddr()
        {
            Assert.AreEqual(a("c"), abc.Caddr());
        }

        [TestMethod]
        public void Eval()
        {
            VariablesEnvironment env = new VariablesEnvironment();
            List list = l(new[] { "+", "2", "3" });
            Assert.AreEqual(a("5"), list.Eval(env));
        }

        [TestMethod]
        public void EvalNestedLists()
        {
            VariablesEnvironment env = new VariablesEnvironment();
            List list = l(new Sexpr[] { a("+"), a("3"), l(new[] { "+", "2", "3" }) });
            Assert.AreEqual(a("8"), list.Eval(env));
        }


        [TestMethod]
        public void EvalDefine()
        {
            define("x", a("3"));
            Assert.AreEqual(Atom.s("6"), l(new[] { "+", "x", "3" }).Eval(env));
        }

        [TestMethod]
        public void EvalLambda()
        {
            VariablesEnvironment env = new VariablesEnvironment();
            Assert.IsTrue(Lambda().Eval(env) is Function);
        }

        [TestMethod]
        public void EvalLambdaApply()
        {
            VariablesEnvironment env = new VariablesEnvironment();           
            List list = l(new Sexpr[] { Lambda(), a("3") });
            Assert.AreEqual(a("5"), list.Eval(env));
        }

        private List Lambda()
        {
            return l(new Sexpr[] { a("lambda"), l(new Sexpr[] { }), l(new[] { "+", "2", "3" }) });
        }

        private void define(string variableName, Sexpr value)
        {
            var definition = l(new Sexpr[] { a("define"), a(variableName), value });
            definition.Eval(env);
        }
    }
}
