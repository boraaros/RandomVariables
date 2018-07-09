using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomVariables
{
    [Serializable]
    public sealed class Exponential : IEquatable<Exponential>, IFormattable
    {
        public double Lambda { get; }

        private static readonly Random random = new Random();

        public Exponential(double lambda) => 
            Lambda = lambda > 0 ? lambda : throw new ArgumentOutOfRangeException(nameof(lambda), lambda, "must be positive");

        public double ExpectedValue => 
            1 / Lambda;

        public double StandardDeviation => 
            1 / Lambda;

        public double Variance =>
            1 / Math.Pow(Lambda, 2);

        public double RandomValue() => 
            Math.Log((1 - random.NextDouble()) / -Lambda);

        public double Distribution(double x) => 
            x < 0 ? 0 : 1 - Math.Pow(Math.E, -Lambda * x);

        public double Density(double x) => 
            x < 0 ? 0 : Lambda * Math.Pow(Math.E, -Lambda * x);

        public static Gamma operator +(Exponential e1, Exponential e2) => 
            e1.Lambda == e2.Lambda ? new Gamma(2, e1.Lambda) : throw new NotImplementedException($"{e1} + {e2}");

        public static Gamma operator +(Exponential e, Gamma g) => 
            e.Lambda == g.Beta ? new Gamma(g.Alpha + 1, e.Lambda) : throw new NotImplementedException($"{e} + {g}");

        public static Laplace operator -(Exponential e1, Exponential e2) =>
            e1.Lambda == e2.Lambda ? new Laplace(0, 1 / e1.Lambda) : throw new NotImplementedException($"{e1} - {e2}");

        public static Exponential operator *(Exponential e, double c) => 
            c > 0 ? new Exponential(e.Lambda / c) : throw new ArgumentOutOfRangeException(nameof(c), c, "must be positive");

        public static Exponential Min(Exponential e1, Exponential e2) => 
            new Exponential(e1.Lambda + e2.Lambda);

        public static Exponential Min(ICollection<Exponential> e) => 
            new Exponential(e.Sum(t => t.Lambda));

        public static bool operator ==(Exponential e1, Exponential e2) => 
            e1.Equals(e2);

        public static bool operator !=(Exponential e1, Exponential e2) => 
            !(e1 == e2);

        public override int GetHashCode() => 
            Lambda.GetHashCode();

        public bool Equals(Exponential other) => 
            other != null && Lambda == other.Lambda;

        public override bool Equals(object obj) => 
            Equals(obj as Exponential);

        public override string ToString() => 
            $"Exp({Lambda})";

        public string ToString(string format, IFormatProvider formatProvider) => 
            $"Exp({Lambda.ToString(format, formatProvider)})";
    }
}