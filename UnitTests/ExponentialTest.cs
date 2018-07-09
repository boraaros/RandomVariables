using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomVariables;

namespace UnitTests
{
    [TestClass]
    public class ExponentialTest
    {
        [TestMethod]
        public void Exp_sum_with_same_parameter()
        {
            var x1 = new Exponential(0.3);
            var x2 = new Exponential(0.3);

            var result = x1 + x2;

            Assert.IsInstanceOfType(result, typeof(Gamma));
            Assert.AreEqual(2, result.Alpha);
            Assert.AreEqual(0.3, result.Beta);
        }
    }
}