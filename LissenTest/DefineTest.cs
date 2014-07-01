using Lissen;
using NFluent;
using NUnit.Framework;
using List = Lissen.List;

namespace LissenTest
{
    public class DefineTest : SexprHelpers
    {
        [Test]
        public void DefineVariable()
        {
            var env = new VariablesEnvironment();
            var par = l(new[] { "x", "3" });

            var def = new Define();
            def.ApplyOn(par, env);

            Check.That(env.IsDefined(a("x"))).IsTrue();
            Check.That(env.Find(a("x"))).Equals(Atom.s("3"));
        }

        [Test]
        public void DefineFunctionAsLambda()
        {
            var env = new VariablesEnvironment();
            var args = l(new[] { "add", "x", "y" });
            var form = l(new[] { "+", "x", "y" });
            var def = l(new Sexpr[] { args, form });

            var define = new Define();
            define.ApplyOn(def, env);

            Check.That(env.IsDefined(a("add"))).IsTrue();
        }
    }
}
