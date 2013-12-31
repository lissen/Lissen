using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lissen;

namespace LissenTest
{
    [TestClass]
    public class PairTest
    {
        [TestMethod]
        public void ConsSymbols()
        {
            Pair p = Pair.Cons(Atom.s("1"), Atom.s("2"));

            Assert.AreEqual("1", p.Car.ToString());
            Assert.AreEqual("2", p.Cdr.ToString());
        }

        [TestMethod]
        public void ConsPairs()
        {
            Pair p = Pair.Cons(Atom.s("1"), Pair.Cons(Atom.s("2"), null));

            Assert.AreEqual("2", ((Pair)p.Cdr).Car.ToString());
            Assert.AreEqual(null, ((Pair)p.Cdr).Cdr);
        }
    }
}
