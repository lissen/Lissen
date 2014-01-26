using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lissen;

namespace LissenTest
{
    [TestClass]
    public class ListTest
    {
        private List L;

        [TestInitialize]
        public void SetUp()
        {
            L = l(new[] { "a", "b", "c" });
        }

        [TestMethod]
        public void Car()
        {
            Assert.AreEqual(a("a"), L.Car());
        }

        [TestMethod]
        public void Cdr()
        {
            Assert.AreEqual(l(new[] { "b", "c" }), L.Cdr());
        }

        [TestMethod]
        public void Cadr()
        {
            Assert.AreEqual(a("b"), L.Cadr());
        }

        [TestMethod]
        public void Caddr()
        {
            Assert.AreEqual(a("c"), L.Caddr());
        }

        private Atom a(string s)
        {
            return Atom.s(s);
        }

        private List l(string[] stringList)
        {
            List list = new List();
            foreach (string s in stringList)
            {
                list.Add(a(s));
            }
            return list;
        }
    }
}
