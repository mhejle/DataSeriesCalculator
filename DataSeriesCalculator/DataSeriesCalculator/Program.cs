using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using DataSeriesCalculator.Calculation.AsCompositePattern;
using DataSeriesCalculator.Calculation.AsFluent;

namespace DataSeriesCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var resultOfCompositePattern = CalculateUsingCompositePattern();
            Console.Out.WriteLine("Composite : " + resultOfCompositePattern);

            var resultOfFluent = CalculateUsingFluent();
            Console.Out.WriteLine("Fluent : " + resultOfFluent);
            Console.ReadKey();

        }

        private static string CalculateUsingFluent()
        {
            //((s1 + s2 + s3) * 100 ) + (s4 + s5)
            var s1 = new FluentDataSeries(new[] { 1, 2, 3, 4 });
            var s2 = new FluentDataSeries(new[] { 4, 3, 2, 1 });
            var s3 = new FluentDataSeries(new[] { 1, 1, 1, 2 });
            var s4 = new FluentDataSeries(new[] { 1, 10, 100, 1000 });
            var s5 = new FluentDataSeries(new[] { 2, 20, 200, 2000 });

            var s4S5 = s4.Add(s5);

            s1
                .Add(s2)
                .Add(s3)
                .MultiplyByConstant(100)
                .Add(s4S5);

            return s1.Data.ToString();
        }

        private static string CalculateUsingCompositePattern()
        {
            //((s1 + s2 + s3) * 100 ) + (s4 + s5)
            var s1 = new DataSeriesLeaf(new[] {1, 2, 3, 4});
            var s2 = new DataSeriesLeaf(new[] {4, 3, 2, 1});
            var s3 = new DataSeriesLeaf(new[] {1, 1, 1, 2});
            var s4 = new DataSeriesLeaf(new[] {1, 10, 100, 1000});
            var s5 = new DataSeriesLeaf(new[] {2, 20, 200, 2000 });

            IComponent addingS1S2AndS3 = new AdderComposite(new List<IComponent> {s1, s2, s3}); //6,6,6,7
            IComponent multiplyingBy100 = new MultiplyByConstantComposite(addingS1S2AndS3, 100);//600,600,600,700
            IComponent addingS4S5 = new AdderComposite(new List<IComponent> {s4, s5 });//3,30,300,3000
            IComponent addingResultOfS4S5 = new AdderComposite(new List<IComponent> { multiplyingBy100, addingS4S5 });//603,630,900,3700
            string resultOfCompositePattern = addingResultOfS4S5.Calculate().ToString();
            return resultOfCompositePattern;
        }
    }
}
