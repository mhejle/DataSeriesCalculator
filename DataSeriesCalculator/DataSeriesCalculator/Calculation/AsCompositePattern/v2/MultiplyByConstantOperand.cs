using DataSeriesCalculator.DataStructures;

namespace DataSeriesCalculator.Calculation.AsCompositePattern.v2
{
    public class MultiplyByConstantOperand : TimeSeriesNumberOperand
    {
        public MultiplyByConstantOperand(IComponent lh, int constant)
            :base(lh,constant)
        {
        }

        public override DataSeries Calculate()
        {
            var dataSeries = Lh.Calculate();
            for (int i = 0; i < dataSeries.Points.Length; i++)
            {
                dataSeries.Points[i] = dataSeries.Points[i]*Constant;
            }
            return dataSeries;
        }
    }
}
