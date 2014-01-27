using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lissen;

namespace LissenTest
{
    [TestClass]
    public class ParserTest : SexprHelpers
    {
        [TestMethod]
        public void LonesomeAtom()
        {
            Parser p = new Parser();
            Assert.AreEqual(a("a"), p.Parse("a")[0]);
        }

        [TestMethod]
        public void ListOfOneAtom()
        {
            Parser parser = new Parser();
            Assert.AreEqual(l(new[] { a("a") }), parser.Parse("(a)")[0]);            
        }

        [TestMethod]
        public void ListOfAtoms()
        {
            Parser parser = new Parser();
            Assert.AreEqual(ab(), parser.Parse("(a b)")[0]);                        
        }

        [TestMethod]
        public void ListOfLists()
        {
            Parser parser = new Parser();

            Assert.AreEqual(abc(), parser.Parse("((a b) c)")[0]);

            Assert.AreEqual(dabc(), parser.Parse("(d ((a b) c))")[0]);
        }

        [TestMethod]
        public void DeepList()
        {
            Parser parser = new Parser();
            List edabcf = l(new Sexpr[] {a("e"), dabc(), a("f")});
            Assert.AreEqual(edabcf, parser.Parse("(e (d ((a b) c)) f)")[0]);          
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ErrorNoEnd()
        {
            Parser parser = new Parser();
            parser.Parse("(e");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ErrorNoStart()
        {
            Parser parser = new Parser();
            parser.Parse("(a b) d)");
        }

        [TestMethod]
        public void MultiLines()
        {
            var lines = @"
                (d ((a b)
                    c)
                )";
            Parser parser = new Parser();
            Assert.AreEqual(dabc(), parser.Parse(lines)[0]);
        }

        [TestMethod]
        public void MultiSexpr()
        {
            var lines = @"
                ((a b) 
                    c)

                (d ((a b)
                    c)
                )";
            Parser parser = new Parser();
            Assert.AreEqual(abc(), parser.Parse(lines)[0]);
            Assert.AreEqual(dabc(), parser.Parse(lines)[1]);
        }

        private List ab()
        {
            return l(new[] {a("a"), a("b")});
        }

        private List abc()
        {
            return l(new Sexpr[] {ab(), a("c")});
        }

        private List dabc()
        {
            return l(new Sexpr[] {a("d"), abc()});
        }
    }
}
