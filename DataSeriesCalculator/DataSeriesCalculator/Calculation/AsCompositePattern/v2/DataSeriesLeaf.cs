using DataSeriesCalculator.DataStructures;

namespace DataSeriesCalculator.Calculation.AsCompositePattern.v2
{
    public class DataSeriesLeaf : IComponent
    {
        private readonly DataSeries _dataSeries;

        public DataSeriesLeaf(int[] dataPoints)
        {
            _dataSeries = new DataSeries
            {
                Points = dataPoints
            };
        }

        public DataSeries Calculate()
        {
            return _dataSeries;
        }
    }
}
