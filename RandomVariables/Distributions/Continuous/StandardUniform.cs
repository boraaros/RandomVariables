using System;

namespace RandomVariables.Distributions.Continuous
{
    [Serializable]
    public class StandardUniform : Uniform
    {
        public StandardUniform(double lowerBound, double upperBound) 
            : base(0, 1)
        {
        }
    }
}