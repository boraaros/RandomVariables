using System;

namespace RandomVariables.Distributions.Continuous
{
    public class StandardUniform : Uniform
    {
        public StandardUniform(double lowerBound, double upperBound) 
            : base(0, 1)
        {
        }
    }
}