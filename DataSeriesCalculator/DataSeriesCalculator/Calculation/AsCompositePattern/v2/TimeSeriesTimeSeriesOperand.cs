using DataSeriesCalculator.DataStructures;

namespace DataSeriesCalculator.Calculation.AsCompositePattern.v2
{
    public abstract class TimeSeriesTimeSeriesOperand : IComponent
    {
        public abstract DataSeries Calculate();

        protected readonly IComponent Lh;
        protected readonly IComponent Rh;

        protected TimeSeriesTimeSeriesOperand(IComponent lh, IComponent rh)
        {
            Lh = lh;
            Rh = rh;
        }

    }
}
