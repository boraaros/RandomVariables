using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomVariables.Distributions.Continuous
{
    public class Exponential : Gamma
    {
        public double Lambda => Rate;

        public Exponential(double lambda) 
            : base(1, lambda)
        {
        }

        public override double RandomValue() =>
            Math.Log((1 - random.NextDouble()) / -Lambda);

        public override double Distribution(double x) =>
            x < 0 ? 0 : 1 - Math.Pow(Math.E, -Lambda * x);

        public override double Density(double x) =>
            x < 0 ? 0 : Lambda * Math.Pow(Math.E, -Lambda * x);

        public static Gamma operator +(Exponential e1, Exponential e2) =>
            e1.Lambda == e2.Lambda ? new Gamma(2, e1.Lambda) : throw new NotImplementedException($"{e1} + {e2}");

        public static Gamma operator +(Exponential e, Gamma g) =>
            e.Lambda == g.Rate ? new Gamma(g.Shape + 1, e.Lambda) : throw new NotImplementedException($"{e} + {g}");

        public static Laplace operator -(Exponential e1, Exponential e2) =>
            e1.Lambda == e2.Lambda ? new Laplace(0, 1 / e1.Lambda) : throw new NotImplementedException($"{e1} - {e2}");

        public static Exponential operator *(Exponential e, double c) =>
            c > 0 ? new Exponential(e.Lambda / c) : throw new ArgumentOutOfRangeException(nameof(c), c, "must be positive");

        public static Exponential Min(Exponential e1, Exponential e2) =>
            new Exponential(e1.Lambda + e2.Lambda);

        public static Exponential Min(ICollection<Exponential> e) =>
            new Exponential(e.Sum(t => t.Lambda));

        public override string ToString() =>
            $"Exp({Lambda})";

        public override string ToString(string format, IFormatProvider formatProvider) =>
            $"Exp({Lambda.ToString(format, formatProvider)})";
    }
}