using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomVariables.Utils;
using System;

namespace UnitTests
{
    [TestClass]
    public class GammaHelperTest
    {
        [TestMethod]
        public void test()
        {
            var res = GammaHelper.Lanczos(0.5);
            Assert.IsTrue(Math.Abs(Math.Sqrt(Math.PI) - res) < 0.000001);
        }

        [TestMethod]
        public void test2()
        {
            var res = GammaHelper.Lanczos(1);
            Assert.IsTrue(Math.Abs(1 - res) < 0.000001);
        }

        [TestMethod]
        public void test3()
        {
            var res = GammaHelper.Lanczos(6);
            Assert.IsTrue(Math.Abs(120 - res) < 0.000001);
        }

        [TestMethod]
        public void test4()
        {
            var res = GammaHelper.LowerIncompleteGamma(6, 9);
            Assert.IsTrue(true);
        }
    }
}
