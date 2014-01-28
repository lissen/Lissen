using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lissen;

namespace LissenTest
{
    [TestClass]
    public class VariablesEnvironmentTest : SexprHelpers
    {
        [TestMethod]
        public void StoreVariable()
        {
            var env = new VariablesEnvironment();
            Assert.IsFalse(env.IsDefined(a("a")));
            
            env.Define(a("a"), a("1"));
            
            Assert.IsTrue(env.IsDefined(a("a")));
            Assert.AreEqual(a("1"), env.Find(a("a")));
        }

        [TestMethod]        
        public void UnknownVariableThrowException()
        {
            var env = new VariablesEnvironment();
            try
            {
                env.Find(a("a"));
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Variable undefined"));                  
            }            
        }

        [TestMethod]
        public void BuildInFunctions()
        {
            var env = new VariablesEnvironment();
            Assert.IsTrue(env.IsDefined(a("define")));
            Assert.IsTrue(env.IsDefined(a("+")));
            Assert.IsTrue(env.IsDefined(a("lambda")));
            Assert.IsTrue(env.Find(a("+")) is Function);
        }

        [TestMethod]
        public void NestedEnv()
        {
            var parentEnv = new VariablesEnvironment();
            parentEnv.Define(a("x"), a("3"));
            var env = new VariablesEnvironment(parentEnv);
            env.Define(a("y"), a("4"));
            Assert.AreEqual(a("3"), env.Find(a("x")));
            Assert.AreEqual(a("4"), env.Find(a("y")));
        }
    }
}
