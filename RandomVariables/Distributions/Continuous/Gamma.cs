using RandomVariables.Utils;
using System;

namespace RandomVariables.Distributions.Continuous
{
    [Serializable]
    public class Gamma : IEquatable<Gamma>, IFormattable
    {
        public double Shape { get; }
        public double Rate { get; }
        public double Scale => 1 / Rate;

        protected static Random random = new Random();

        public Gamma(double shape, double rate) => 
            (Shape, Rate) = (shape > 0 ? shape : throw new ArgumentOutOfRangeException(nameof(shape), shape, "must be positive"), 
                             rate > 0 ? rate : throw new ArgumentOutOfRangeException(nameof(rate), rate, "must be positive"));

        public double ExpectedValue => 
            Shape / Rate; 

        public double StandardDeviation => 
            Math.Sqrt(Shape) / Rate;

        public double Variance => 
            Shape / Math.Pow(Rate, 2);

        public virtual double RandomValue() =>
            throw new NotImplementedException();

        public virtual double Distribution(double x) =>
            x < 0 ? 0 : GammaHelper.LowerIncompleteGamma(Shape, Rate * x) / GammaHelper.Lanczos(Shape);

        public virtual double Density(double x) =>
            x < 0 ? 0 : Math.Pow(Rate, Shape) * Math.Pow(x, Shape - 1) * Math.Pow(Math.E, -Rate * x) / GammaHelper.Lanczos(Shape);

        public static Gamma operator +(Gamma g, Exponential e) => 
            e + g;

        public static Gamma operator +(Gamma g1, Gamma g2) => 
            new Gamma(g1.Shape + g2.Shape, g1.Rate);

        public static bool operator ==(Gamma g1, Gamma g2) =>
            g1.Equals(g2);

        public static bool operator !=(Gamma g1, Gamma g2) =>
            !(g1 == g2);

        public override int GetHashCode() =>
            Shape.GetHashCode() ^ Rate.GetHashCode();

        public bool Equals(Gamma other) =>
            other != null && Shape == other.Shape && Rate == other.Rate;

        public override bool Equals(object obj) =>
            Equals(obj as Gamma);

        public override string ToString() => 
            $"Gamma({Shape}, {Rate})";

        public virtual string ToString(string format, IFormatProvider formatProvider) =>
            $"Gamma({Shape.ToString(format, formatProvider)}, {Rate.ToString(format, formatProvider)})";
    }
}