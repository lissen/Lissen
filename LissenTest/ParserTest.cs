using System;
using Lissen;
using NFluent;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using List = Lissen.List;

namespace LissenTest
{
    public class ParserTest : SexprHelpers
    {
        [Test]
        public void LonesomeAtom()
        {
            var p = new Parser();
            Check.That(p.Parse("a")[0]).Equals(a("a"));
        }

        [Test]
        public void ListOfOneAtom()
        {
            var parser = new Parser();
            Check.That(parser.Parse("(a)")[0]).Equals(l(new[] {a("a")}));
        }

        [Test]
        public void ListOfAtoms()
        {
            var parser = new Parser();
            Check.That(parser.Parse("(a b)")[0]).Equals(ab());
        }

        [Test]
        public void ListOfLists()
        {
            var parser = new Parser();
            Check.That(parser.Parse("((a b) c)")[0]).Equals(abc());
            Check.That(parser.Parse("(d ((a b) c))")[0]).Equals(dabc());
        }

        [Test]
        public void DeepList()
        {
            var parser = new Parser();
            var edabcf = l(new Sexpr[] {a("e"), dabc(), a("f")});
            Check.That(parser.Parse("(e (d ((a b) c)) f)")[0]).Equals(edabcf);
        }

        [Test]
        public void EmptyList()
        {
            var parser = new Parser();
            Assert.AreEqual(new List(), parser.Parse("()")[0]);
            var listOfEmptyList = l(new Sexpr[] { new List() });
            Check.That(parser.Parse("(())")[0]).Equals(listOfEmptyList);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void ErrorNoEnd()
        {
            var parser = new Parser();
            parser.Parse("(e");
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void ErrorNoStart()
        {
            var parser = new Parser();
            parser.Parse("(a b) d)");
        }

        [Test]
        public void MultiLines()
        {
            const string lines = @"
                (d ((a b)
                    c)
                )";
            var parser = new Parser();
            Check.That(parser.Parse(lines)[0]).Equals(dabc());
        }

        [Test]
        public void MultiSexpr()
        {
            const string lines = @"
                ((a b) 
                    c)

                (d ((a b)
                    c)
                )";
            var parser = new Parser();
            Check.That(parser.Parse(lines)[0]).Equals(abc());
            Check.That(parser.Parse(lines)[1]).Equals(dabc());
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
