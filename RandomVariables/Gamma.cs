using System;

namespace RandomVariables
{
    [Serializable]
    public sealed class Gamma
    {
        public double Alpha { get; }
        public double Beta { get; }

        public Gamma(double alpha, double beta)
        {
            Alpha = alpha > 0 ? alpha : throw new ArgumentOutOfRangeException(nameof(alpha), alpha, "must be positive");
            Beta = beta > 0 ? beta : throw new ArgumentOutOfRangeException(nameof(beta), beta, "must be positive");
        }

        public double ExpectedValue => 
            Alpha / Beta; 

        public double StandardDeviation => 
            Math.Sqrt(Alpha) / Beta;

        public double Variance => 
            Alpha / Math.Pow(Beta, 2);

        public static Gamma operator +(Gamma g, Exponential e) => 
            e + g;

        public static Gamma operator +(Gamma g1, Gamma g2) => 
            new Gamma(g1.Alpha + g2.Alpha, g1.Beta);

        public static bool operator ==(Gamma g1, Gamma g2) =>
            g1.Equals(g2);

        public static bool operator !=(Gamma g1, Gamma g2) =>
            !(g1 == g2);

        public override int GetHashCode() =>
            Alpha.GetHashCode() ^ Beta.GetHashCode();

        public bool Equals(Gamma other) =>
            other != null && Alpha == other.Alpha && Beta == other.Beta;

        public override bool Equals(object obj) =>
            Equals(obj as Gamma);

        public override string ToString() => 
            $"Gamma({Alpha}, {Beta})";
    }
}