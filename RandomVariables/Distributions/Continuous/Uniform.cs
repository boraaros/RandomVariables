using System;

namespace RandomVariables.Distributions.Continuous
{
    [Serializable]
    public class Uniform : IEquatable<Uniform>, IFormattable
    {
        public double LowerBound { get; }
        public double UpperBound { get; }

        private static readonly Random random = new Random();

        public Uniform(double lowerBound, double upperBound) =>
            (LowerBound, UpperBound) = (lowerBound, upperBound);

        public double ExpectedValue =>
            (UpperBound - LowerBound) / 2;

        public double StandardDeviation =>
            (UpperBound - LowerBound) / Math.Sqrt(12);

        public double Variance =>
            Math.Pow((UpperBound - LowerBound), 2) / 12;

        public double RandomValue() =>
            LowerBound + (UpperBound - LowerBound) * random.NextDouble();

        public double Distribution(double x) =>
            x < LowerBound ? 0 : (x > UpperBound ? 1 : (x - LowerBound) / (UpperBound - LowerBound));

        public double Density(double x) =>
            x < LowerBound || x > UpperBound ? 0 : 1 / (UpperBound - LowerBound);

        public static Exponential Min(Exponential e1, Exponential e2) =>
            new Exponential(e1.Lambda + e2.Lambda);

        public static bool operator ==(Uniform e1, Uniform e2) =>
            e1.Equals(e2);

        public static bool operator !=(Uniform e1, Uniform e2) =>
            !(e1 == e2);

        public override int GetHashCode() =>
            LowerBound.GetHashCode() ^ UpperBound.GetHashCode();

        public bool Equals(Uniform other) =>
            other != null && LowerBound == other.LowerBound && UpperBound == other.UpperBound;

        public override bool Equals(object obj) =>
            Equals(obj as Uniform);

        public override string ToString() =>
            $"U({LowerBound},{UpperBound})";

        public string ToString(string format, IFormatProvider formatProvider) =>
            $"U({LowerBound.ToString(format, formatProvider)},{UpperBound.ToString(format, formatProvider)})";
    }
}