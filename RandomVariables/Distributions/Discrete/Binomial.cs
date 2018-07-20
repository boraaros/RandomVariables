using RandomVariables.Utils;
using System;
using System.Linq;

namespace RandomVariables.Distributions.Discrete
{
    [Serializable]
    public class Binomial : IEquatable<Binomial>, IFormattable
    {
        public int Number { get; }
        public double Probability { get; }

        protected static Random random = new Random();

        public Binomial(int number, double probability) =>
            (Number, Probability) = (number > 0 ? number : throw new ArgumentOutOfRangeException(nameof(number), number, "must be positive"),
                                     probability >= 0 && probability <= 1 ? probability : throw new ArgumentOutOfRangeException(nameof(probability), probability, "must be valid probability value"));

        public double ExpectedValue =>
            Number / Probability;

        public double StandardDeviation =>
            Math.Sqrt(Variance);

        public double Variance =>
            Number * Probability * (1 - Probability);

        public int RandomValue() =>
            Enumerable.Range(0, Number).Count(t => random.NextDouble() < Probability);

        public double Distribution(double x) =>
            Enumerable.Range(0, (int)Math.Floor(x)).Sum(t => Density(t));

        public double Density(int value) => 
            BinomialCoefficient(Number, value) * Math.Pow(Probability, value) * Math.Pow(1 - Probability, Number - value);

        private int BinomialCoefficient(int n, int k) => 
            GammaHelper.Factorial(n) / GammaHelper.Factorial(k) / GammaHelper.Factorial(n - k);

        public static Binomial operator +(Binomial b1, Binomial b2) =>
            b1.Probability == b2.Probability ? new Binomial(b1.Number + b2.Number, b1.Probability) : throw new NotImplementedException($"{b1} + {b2}");

        public static bool operator ==(Binomial b1, Binomial b2) =>
            b1.Equals(b2);

        public static bool operator !=(Binomial b1, Binomial b2) =>
            !(b1 == b2);

        public override int GetHashCode() =>
            Number.GetHashCode() ^ Probability.GetHashCode();

        public bool Equals(Binomial other) =>
            other != null && Number == other.Number && Probability == other.Probability;

        public override bool Equals(object obj) =>
            Equals(obj as Binomial);

        public override string ToString() =>
            $"Binom({Number}, {Probability})";

        public virtual string ToString(string format, IFormatProvider formatProvider) =>
            $"Binom({Number.ToString(format, formatProvider)}, {Probability.ToString(format, formatProvider)})";
    }
}