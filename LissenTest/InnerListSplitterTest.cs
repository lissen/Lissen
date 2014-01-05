using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lissen;

namespace LissenTest
{
    [TestClass]
    public class InnerListSplitterTest
    {
        [TestMethod]
        public void AllPresent()
        {
            string s = "before (inner) after";

            InnerSplitted inner = InnerListSplitter.split(s);

            Assert.AreEqual("before ", inner.before);
            Assert.AreEqual("(inner)", inner.inner);
            Assert.AreEqual(" after", inner.after);
        }

        [TestMethod]
        public void EmtyBefore()
        {
            string s = "(inner) after";

            InnerSplitted inner = InnerListSplitter.split(s);

            Assert.AreEqual("", inner.before);
            Assert.AreEqual("(inner)", inner.inner);
            Assert.AreEqual(" after", inner.after);
        }

        [TestMethod]
        public void EmtyAfter()
        {
            string s = "before (inner)";

            InnerSplitted inner = InnerListSplitter.split(s);

            Assert.AreEqual("before ", inner.before);
            Assert.AreEqual("(inner)", inner.inner);
            Assert.AreEqual("", inner.after);
        }

        [TestMethod]
        public void EmtyInner()
        {
            string s = "before () after";

            InnerSplitted inner = InnerListSplitter.split(s);

            Assert.AreEqual("before ", inner.before);
            Assert.AreEqual("()", inner.inner);
            Assert.AreEqual(" after", inner.after);
        }

        [TestMethod]
        public void NoInnerList()
        {
            string s = "before after";

            InnerSplitted inner = InnerListSplitter.split(s);

            Assert.AreEqual("", inner.before);
            Assert.AreEqual("", inner.inner);
            Assert.AreEqual("before after", inner.after);
        }

        [TestMethod]
        public void OnlyInner()
        {
            string s = "(inner)";

            InnerSplitted inner = InnerListSplitter.split(s);

            Assert.AreEqual("", inner.before);
            Assert.AreEqual("(inner)", inner.inner);
            Assert.AreEqual("", inner.after);
        }
    }
}
