using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DataSeriesCalculator.DataStructures;

namespace DataSeriesCalculator.Calculation.AsCompositePattern
{
    public class MultiplyByConstantComposite : Composite
    {
        private readonly IComponent _lhComponent;
        private readonly int _constant;

        public MultiplyByConstantComposite(IComponent lhComponent, int constant)
        {
            _lhComponent = lhComponent;
            _constant = constant;
        }

        public override DataSeries Calculate()
        {
            var dataSeries = _lhComponent.Calculate();
            for (int i = 0; i < dataSeries.Points.Length; i++)
            {
                dataSeries.Points[i] = dataSeries.Points[i]*_constant;
            }
            return dataSeries;
        }
    }
}
