using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using DataSeriesCalculator.Calculation.AsCompositePattern;
using DataSeriesCalculator.Calculation.AsCompositePattern.v1;
using DataSeriesCalculator.Calculation.AsCompositePattern.v2;
using DataSeriesCalculator.Calculation.AsFluent;
using DataSeriesLeaf = DataSeriesCalculator.Calculation.AsCompositePattern.v1.DataSeriesLeaf;
using IComponent = DataSeriesCalculator.Calculation.AsCompositePattern.IComponent;

namespace DataSeriesCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var resultOfCompositePatternV1 = CalculateUsingCompositePatternV1();
            Console.Out.WriteLine("CompositeV1 : " + resultOfCompositePatternV1);

            var resultOfCompositePatternV2 = CalculateUsingCompositePatternV2();
            Console.Out.WriteLine("CompositeV2 : " + resultOfCompositePatternV2);

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

        private static string CalculateUsingCompositePatternV1()
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

        private static string CalculateUsingCompositePatternV2()
        {
            //((s1 + s2 + s3) * 100 ) + (s4 + s5)
            var s1 = new DataSeriesLeaf(new[] { 1, 2, 3, 4 });
            var s2 = new DataSeriesLeaf(new[] { 4, 3, 2, 1 });
            var s3 = new DataSeriesLeaf(new[] { 1, 1, 1, 2 });
            var s4 = new DataSeriesLeaf(new[] { 1, 10, 100, 1000 });
            var s5 = new DataSeriesLeaf(new[] { 2, 20, 200, 2000 });

            IComponent addingS1AndS2 = new AditionOperand(s1, s2); //5,5,5,5
            IComponent addingS3 = new AditionOperand(addingS1AndS2, s3); //6,6,6,7
            IComponent multiplyingBy100 = new MultiplyByConstantOperand(addingS3, 100);//600,600,600,700
            IComponent addingS4S5 = new AditionOperand(s4, s5);//3,30,300,3000
            IComponent addingResultOfS4S5 = new AditionOperand(multiplyingBy100, addingS4S5);//603,630,900,3700
            string resultOfCompositePattern = addingResultOfS4S5.Calculate().ToString();
            return resultOfCompositePattern;
        }
    }
}
