using DataSeriesCalculator.DataStructures;

namespace DataSeriesCalculator.Calculation.AsFluent
{
    internal class FluentDataSeries
    {
        public DataSeries Data { get; }

        public FluentDataSeries(int[] dataPoints)
        {
            Data = new DataSeries
            {
                Points = dataPoints
            };
        }

        public FluentDataSeries Add(FluentDataSeries s2)
        {
            //non optimized calculation
            var numberOfElementsInDataSeries = s2.Data.Points.Length;
            for (int i = 0; i < numberOfElementsInDataSeries; i++)
            {
                Data.Points[i] += s2.Data.Points[i];
            }

            return this;
        }

        public FluentDataSeries MultiplyByConstant(int constant)
        {
            for (int i = 0; i < Data.Points.Length; i++)
            {
                Data.Points[i] *= constant;
            }

            return this;
        }
    }
}