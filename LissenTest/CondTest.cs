using Lissen;
using NFluent;
using NUnit.Framework;

namespace LissenTest
{
    public class CondTest : SexprHelpers
    {
        [Test]
        public void CondTrue()
        {
            var env = new VariablesEnvironment();
            var cond1 = l(new[] { "#t", "a"});
            var par = l(new Sexpr[] { cond1 });
            var condFunction = new Cond();
            Check.That(condFunction.ApplyOn(par, env)).Equals(Atom.s("a"));
        }

        [Test]
        public void CondLastIsTrue()
        {
            var env = new VariablesEnvironment();
            var cond1 = l(new[] { "()", "a" });
            var cond2 = l(new[] { "#t", "b" });
            var par = l(new Sexpr[] { cond1, cond2 });
            var condFunction = new Cond();
            Check.That(condFunction.ApplyOn(par, env)).Equals(a("b"));
        }

        [Test]
        public void CondAllFalse()
        {
            var env = new VariablesEnvironment();
            var cond1 = l(new[] { "()", "a" });
            var cond2 = l(new[] { "()", "b" });
            var par = l(new Sexpr[] { cond1, cond2 });
            var condFunction = new Cond();
            Check.That(condFunction.ApplyOn(par, env)).Equals(new Nil());
        }

        [Test]
        public void CondWithElse()
        {
            var env = new VariablesEnvironment();
            var cond1 = l(new[] { "()", "a" });
            var cond2 = l(new[] { "()", "b" });
            var cond3 = l(new[] { "else", "c" });
            var par = l(new Sexpr[] { cond1, cond2, cond3 });
            var condFunction = new Cond();
            Check.That(condFunction.ApplyOn(par, env)).Equals(a("c"));
        }
    }
}
