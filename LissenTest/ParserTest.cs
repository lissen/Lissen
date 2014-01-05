using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lissen;

namespace LissenTest
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void LonesomeAtom()
        {
            Parser p = new Parser();
            Assert.AreEqual(atom("a"), p.Parse("a"));
        }

        [TestMethod]
        public void ListOfOneAtom()
        {
            Parser parser = new Parser();
            Assert.AreEqual(l(new[] {atom("a")}), parser.Parse("(a)"));            
        }

        [TestMethod]
        public void ListOfAtoms()
        {
            Parser parser = new Parser();
            Assert.AreEqual(ab(), parser.Parse("(a b)"));                        
        }

        [TestMethod]
        public void ListOfLists()
        {
            Parser parser = new Parser();

            Assert.AreEqual(abc(), parser.Parse("((a b) c)"));

            Assert.AreEqual(dabc(), parser.Parse("(d ((a b) c))"));
        }

        [TestMethod]
        public void DeepList()
        {
            Parser parser = new Parser();
            List edabcf = l(new Symbol[] {atom("e"), dabc(), atom("f")});
            Assert.AreEqual(edabcf, parser.Parse("(e (d ((a b) c)) f)"));          
        }

        private List ab()
        {
            return l(new[] {atom("a"), atom("b")});
        }

        private List abc()
        {
            return l(new Symbol[] {ab(), atom("c")});
        }

        private List dabc()
        {
            return l(new Symbol[] {atom("d"), abc()});
        }

        private Atom atom(string s)
        {
            return Atom.s(s);
        }

        private List l(Symbol[] symbols)
        {
            List list = new List();
            list.AddRange(symbols);
            return list;
        }
    }
}
