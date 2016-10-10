using System;
using System.Collections.Generic;
using System.Text;

namespace DataSeriesCalculator.DataStructures
{
    public class DataSeries 
    {
        public int[] Points { get; set; }
        public DataSeries(int capacity)
        {
            Points = new int[capacity];
        }

        public DataSeries()
        {
        }

        public override string ToString()
        {
            var asString = new StringBuilder();
            foreach (var i in Points)
            {
                asString.Append(i + " ");
            }
            return asString.ToString();
        }
    }
}
