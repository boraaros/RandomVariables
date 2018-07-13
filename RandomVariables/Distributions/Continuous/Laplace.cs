using System;

namespace RandomVariables.Distributions.Continuous
{
    public sealed class Laplace
    {
        public double Mu { get; }
        public double Lambda { get; }

        private static readonly Random random = new Random();

        public Laplace(double mu, double lambda)
        {
            Mu = mu;
            Lambda = lambda > 0 ? lambda : throw new ArgumentOutOfRangeException(nameof(lambda), lambda, "must be positive");
        }

        public Laplace(double lambda)
            : this(0, lambda)
        {
        }

        public double ExpectedValue => 
            Mu;

        public double StandardDeviation => 
            Math.Sqrt(2) * Lambda;

        public double Variance =>
            2 * Math.Pow(Lambda, 2);
    }
}
