using DataSeriesCalculator.DataStructures;

namespace DataSeriesCalculator.Calculation.AsCompositePattern.v1
{
    public abstract class Composite : IComponent
    {
        public abstract DataSeries Calculate();
    }
}
