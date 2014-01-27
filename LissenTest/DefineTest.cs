using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lissen;

namespace LissenTest
{
    [TestClass]
    public class DefineTest : SexprHelpers
    {
        [TestMethod]
        public void Accepted()
        {
            Assert.IsTrue(Define.IsAccepted(Atom.s("define")));
            Assert.IsFalse(Define.IsAccepted(Atom.s("dummy")));
        }

        [TestMethod]
        public void Variable()
        {
            var env = new VariablesEnvironment();
            List par = l(new[] { "x", "3" });

            Define def = new Define();
            def.ApplyOn(par, env);

            Assert.IsTrue(env.IsDefined(a("x")));
            Assert.AreEqual(Atom.s("3"), env.Find(a("x")));
        }
    }
}
