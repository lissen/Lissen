using System;
using Lissen;
using NFluent;
using NUnit.Framework;

namespace LissenTest
{
    public class VariablesEnvironmentTest : SexprHelpers
    {
        [Test]
        public void StoreVariable()
        {
            var env = new VariablesEnvironment();
            Check.That(env.IsDefined(a("a"))).IsFalse();
           
            env.Define(a("a"), a("1"));

            Check.That(env.IsDefined(a("a"))).IsTrue();
            Check.That(env.Find(a("a"))).Equals(a("1"));
        }

        [Test]        
        public void UnknownVariableThrowException()
        {
            var env = new VariablesEnvironment();
            try
            {
                env.Find(a("a"));
            }
            catch (Exception ex)
            {
                Check.That(ex.Message).Contains("Variable undefined");
            }            
        }

        [Test]
        public void BuildInFunctions()
        {
            var env = new VariablesEnvironment();
            Check.That(env.IsDefined(a("define"))).IsTrue();
            Check.That(env.IsDefined(a("+"))).IsTrue();
            Check.That(env.IsDefined(a("lambda"))).IsTrue();
            Check.That(env.Find(a("+")) is Function).IsTrue();
        }

        [Test]
        public void NestedEnv()
        {
            var parentEnv = new VariablesEnvironment();
            parentEnv.Define(a("x"), a("3"));
            var env = new VariablesEnvironment(parentEnv);
            env.Define(a("y"), a("4"));
            Check.That(env.Find(a("x"))).Equals(a("3"));
            Check.That(env.Find(a("y"))).Equals(a("4"));
            Check.That(env.IsDefined(a("x"))).IsTrue();
        }
    }
}
