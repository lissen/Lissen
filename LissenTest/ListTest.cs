using Lissen;
using NFluent;
using NUnit.Framework;
using List = Lissen.List;

namespace LissenTest
{
    public class ListTest : SexprHelpers
    {
        private List abc;
        private VariablesEnvironment env;

        [SetUp]
        public void SetUp()
        {
            abc = l(new[] { "a", "b", "c" });
            env = new VariablesEnvironment();
        }

        [Test]
        public void Car()
        {
            Check.That(abc.Car()).Equals(a("a"));
        }

        [Test]
        public void Cdr()
        {
            Check.That(abc.Cdr()).Equals(l(new[] { "b", "c" }));
        }

        [Test]
        public void Cadr()
        {
            Check.That(abc.Cadr()).Equals(a("b"));
        }

        [Test]
        public void Caddr()
        {
            Check.That(abc.Caddr()).Equals(a("c"));
        }

        [Test]
        public void Eval()
        {
            var env = new VariablesEnvironment();
            var list = l(new[] { "+", "2", "3" });
            Check.That(list.Eval(env)).Equals(a("5"));
        }

        [Test]
        public void EvalNestedLists()
        {
            var env = new VariablesEnvironment();
            var list = l(new Sexpr[] { a("+"), a("3"), l(new[] { "+", "2", "3" }) });
            Check.That(list.Eval(env)).Equals(a("8"));
        }

        [Test]
        public void EvalDefine()
        {
            define("x", a("3"));
            Check.That(l(new[] {"+", "x", "3"}).Eval(env)).Equals(Atom.s("6"));
        }

        [Test]
        public void EvalLambda()
        {
            var env = new VariablesEnvironment();
            Check.That(Lambda().Eval(env) is Function).IsTrue();
        }

        [Test]
        public void EvalLambdaApply()
        {
            var env = new VariablesEnvironment();           
            var list = l(new Sexpr[] { Lambda(), a("3") });
            Check.That(list.Eval(env)).Equals(a("5"));
        }

        private List Lambda()
        {
            return l(new Sexpr[] { a("lambda"), l(new Sexpr[] { }), l(new[] { "+", "2", "3" }) });
        }

        private void define(string variableName, Sexpr value)
        {
            var definition = l(new Sexpr[] { a("define"), a(variableName), value });
            definition.Eval(env);
        }
    }
}
