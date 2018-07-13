using System;
using System.Linq;

namespace RandomVariables.Utils
{
    public static class GammaHelper
    {
        private static double[] p = 
        {
            0.99999999999980993,
            676.5203681218851,
            -1259.1392167224028,
            771.32342877765313,
            -176.61502916214059,
            12.507343278686905,
            -0.13857109526572012,
            9.9843695780195716e-6,
            1.5056327351493116e-7
        };

        public static double Lanczos(double x)
        {
            if (x < 0.5)
            {
                return Math.PI / (Math.Sin(Math.PI * x) * Lanczos(1 - x));
            }
            else
            {
                double y = p[0] + Enumerable.Range(1, p.Length - 1).Select(i => p[i] / (x - 1 + i)).Sum();
                return Math.Sqrt(2 * Math.PI) * (Math.Pow(x + p.Length - 2.5, x - 0.5)) * Math.Exp(-x - p.Length + 2.5) * y;
            }
        }

        public static double LowerIncompleteGamma(double a, double x)
        {
            return Math.Pow(x, a) * Enumerable.Range(0, 100).Select(k => Math.Pow(-1, k) * Math.Pow(x, k) / (a + k) / Factorial(k)).Sum();
        }

        private static int Factorial(int k)
        {
            var sum = 1;
            for (int i = 1; i <= k; i++)
            {
                sum *= k; 
            }
            return sum;
        }
    }
}