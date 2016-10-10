using DataSeriesCalculator.DataStructures;

namespace DataSeriesCalculator.Calculation.AsCompositePattern.v2
{
    /// <summary>
    /// only supports addition of equal lenght dataSeries
    /// </summary>
    public class AditionOperand : TimeSeriesTimeSeriesOperand
    {

        public AditionOperand(IComponent lh , IComponent rh)
            :base(lh, rh)
        {
        }

        public override DataSeries Calculate()
        {
            //non optimized calculation
            var lhResult = Lh.Calculate().Points;
            var rhResult = Rh.Calculate().Points;
            var result = new DataSeries(lhResult.Length);
            for (int i = 0; i < lhResult.Length; i++)
            {
                int resultForIndex = lhResult[i] + rhResult[i];
                result.Points[i] = resultForIndex;
            }

            return result;
        }
    }
}
