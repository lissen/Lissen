using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lissen;

namespace LissenTest
{
    [TestClass]
    public class CarTest : SexprHelpers
    {
        [TestMethod]
        public void Car()
        {
            var env = new VariablesEnvironment();
            var arg = l(new[] { "a", "b", "c"});
            var carFunction = new Car();
            Assert.AreEqual(a("a"), carFunction.ApplyOn(arg, env));
        }
    }
}
