using DataSeriesCalculator.DataStructures;

namespace DataSeriesCalculator.Calculation.AsCompositePattern
{
    public interface IComponent
    {
        DataSeries Calculate();
    }
}
