using System.Collections.Generic;
using DataSeriesCalculator.DataStructures;

namespace DataSeriesCalculator.Calculation.AsCompositePattern
{
    public abstract class Composite : IComponent
    {
        public abstract DataSeries Calculate();
    }
}
