using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lissen;

namespace LissenTest
{
    [TestClass]
    public class AtomTest
    {
        [TestMethod]
        public void Constructor()
        {
            Atom a = Atom.s("abc");
            Assert.AreEqual("abc", a.ToString());
        }
    }
}
