using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lissen;

namespace LissenTest
{
    [TestClass]
    public class DefineTest : SexprHelpers
    {
        [TestMethod]
        public void DefineVariable()
        {
            var env = new VariablesEnvironment();
            List par = l(new[] { "x", "3" });

            Define def = new Define();
            def.ApplyOn(par, env);

            Assert.IsTrue(env.IsDefined(a("x")));
            Assert.AreEqual(Atom.s("3"), env.Find(a("x")));
        }

        [TestMethod]
        public void DefineFunctionAsLambda()
        {
            var env = new VariablesEnvironment();
            List args = l(new[] { "add", "x", "y" });
            List form = l(new[] { "+", "x", "y" });
            List def = l(new Sexpr[] { args, form });

            Define define = new Define();
            define.ApplyOn(def, env);

            Assert.IsTrue(env.IsDefined(a("add")));
//            Assert.AreEqual(Atom.s("3"), env.Find(a("x")));
        }
    }
}
