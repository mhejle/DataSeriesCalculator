using DataSeriesCalculator.DataStructures;

namespace DataSeriesCalculator.Calculation.AsCompositePattern.v2
{
    public abstract class TimeSeriesNumberOperand : IComponent
    {
        public abstract DataSeries Calculate();

        protected readonly IComponent Lh;
        protected readonly int Constant;

        protected TimeSeriesNumberOperand(IComponent lh, int constant)
        {
            Lh = lh;
            Constant = constant;
        }
    }
}
