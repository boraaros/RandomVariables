using System;

namespace RandomVariables.Distributions.Discrete
{
    [Serializable]
    public class Bernoulli : Binomial
    {
        public Bernoulli(double probability) 
            : base(1, probability)
        {
        }

        public override string ToString() =>
        $"Ind({Probability})";

        public override string ToString(string format, IFormatProvider formatProvider) =>
        $"Ind({Probability.ToString(format, formatProvider)})";
    }
}