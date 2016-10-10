using System;
using System.Collections.Generic;
using DataSeriesCalculator.Calculation.AsCompositePattern;
using DataSeriesCalculator.DataStructures;

namespace DataSeriesCalculator
{
    class Program
    {
        static void Main(string[] args)
        {

            
            var resultOfCompositePattern = CalculateUsingCompositePattern();
            Console.Out.WriteLine(resultOfCompositePattern);
            Console.ReadKey();

        }

        private static string CalculateUsingCompositePattern()
        {
            var s1 = new DataSeriesLeaf(new[] {1, 2, 3, 4});
            var s2 = new DataSeriesLeaf(new[] {4, 3, 2, 1});
            var s3 = new DataSeriesLeaf(new[] {1, 1, 1, 2});
            var s4 = new DataSeriesLeaf(new[] {1, 10, 100, 1000});

            IComponent addingComponentS1S2AndS3 = new AdderComposite(new List<IComponent> {s1, s2, s3}); //6,6,6,7
            IComponent multiplicationComponent = new MultiplyByConstantComposite(addingComponentS1S2AndS3, 100);//600,600,600,700
            IComponent addingComponent = new AdderComposite(new List<IComponent> {multiplicationComponent, s4});//601,610,700,1700
            string resultOfCompositePattern = addingComponent.Calculate().ToString();
            return resultOfCompositePattern;
        }
    }
}
