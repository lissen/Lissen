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
            Assert.AreEqual(Atom.s("a"), p.Parse("a"));
        }

        [TestMethod]
        public void ListOfOneAtom()
        {
            Parser p = new Parser();
            Pair pair = Pair.Cons(Atom.s("a"), null); 
            Assert.AreEqual(pair, p.Parse("(a)"));            
        }

        [TestMethod]
        public void ListOfAtoms()
        {
            Parser p = new Parser();
            Pair list = Pair.Cons(Atom.s("a"), Pair.Cons(Atom.s("b"), null)); 
            Assert.AreEqual(list, p.Parse("(a b)"));                        
        }

    }
}
