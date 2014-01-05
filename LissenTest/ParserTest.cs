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
            Pair pair = p(atom("a"), nil);
            Assert.AreEqual(pair, parser.Parse("(a)"));            
        }

        [TestMethod]
        public void ListOfAtoms()
        {
            Parser parser = new Parser();
            Pair list = p(atom("a"), p(atom("b"), nil));
            Assert.AreEqual(list, parser.Parse("(a b)"));                        
        }

        [TestMethod]
        public void ListOfLists()
        {
            Parser parser = new Parser();
            Pair ab = p(atom("a"), p(atom("b"), nil));
            Pair abc = p(ab, p(atom("c"), nil));
            Assert.AreEqual(abc, parser.Parse("((a b) c)"));
        }

        private Atom atom(string s)
        {
            return Atom.s(s);
        }

        private Pair p(Symbol a, Symbol b)
        {
            return Pair.Cons(a, b);
        }

        private Nil nil = new Nil();
    }
}
