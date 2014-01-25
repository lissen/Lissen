using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lissen;

namespace LissenTest
{
    [TestClass]
    public class VariablesEnvironmentTest
    {
        [TestMethod]
        public void StoreVariable()
        {
            VariablesEnvironment env = new VariablesEnvironment();
            Assert.IsFalse(env.IsDefined(Atom.s("a")));
            
            env.Define(Atom.s("a"), Atom.s("1"));
            
            Assert.IsTrue(env.IsDefined(Atom.s("a")));
            Assert.AreEqual(Atom.s("1"), env.Get(Atom.s("a")));
        }

        [TestMethod]        
        public void UnknownVariableThrowException()
        {
            VariablesEnvironment env = new VariablesEnvironment();
            try
            {
                env.Get(Atom.s("a"));
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Variable undefined"));                  
            }            
        }
    }
}
