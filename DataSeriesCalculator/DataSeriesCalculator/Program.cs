using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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
            //((s1 + s2 + s3) * 100 ) + s4
            var s1 = new DataSeriesLeaf(new[] {1, 2, 3, 4});
            var s2 = new DataSeriesLeaf(new[] {4, 3, 2, 1});
            var s3 = new DataSeriesLeaf(new[] {1, 1, 1, 2});
            var s4 = new DataSeriesLeaf(new[] {1, 10, 100, 1000});

            IComponent addingS1S2AndS3 = new AdderComposite(new List<IComponent> {s1, s2, s3}); //6,6,6,7
            IComponent multiplyingBy100 = new MultiplyByConstantComposite(addingS1S2AndS3, 100);//600,600,600,700
            IComponent addingS4 = new AdderComposite(new List<IComponent> {multiplyingBy100, s4});//601,610,700,1700
            string resultOfCompositePattern = addingS4.Calculate().ToString();
            return resultOfCompositePattern;
        }
    }
}
