using System.Collections.Generic;
using System.Linq;
using DataSeriesCalculator.DataStructures;

namespace DataSeriesCalculator.Calculation.AsCompositePattern.v1
{
    /// <summary>
    /// only supports addition of equal lenght dataSeries
    /// </summary>
    public class AdderComposite : Composite
    {
        private readonly List<IComponent> _components;

        public AdderComposite(List<IComponent> components)
        {
            _components = components;
        }

        public override DataSeries Calculate()
        {
            //non optimized calculation

            List<DataSeries> dataSeriesProducedByChildren =new List<DataSeries>();
            foreach (var component in _components)
            {
                dataSeriesProducedByChildren.Add(component.Calculate());
            }

            var numberOfElementsInDataSeries = dataSeriesProducedByChildren.First().Points.Length;
            DataSeries result = new DataSeries(numberOfElementsInDataSeries);
            for (int i = 0; i < numberOfElementsInDataSeries; i++)
            {
                int resultForIndex = 0;
                foreach (var dataSeriesProducedByChild in dataSeriesProducedByChildren)
                {
                    resultForIndex += dataSeriesProducedByChild.Points[i];
                }
                result.Points[i] = resultForIndex;
            }

            return result;
        }
    }
}
