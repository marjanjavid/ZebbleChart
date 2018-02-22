using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart
    {
        public class Box:IPlotType
        {
            public Box()
            {

            }
            public Box(List<BoxPlotItem> data)
            {
                this.Data = data;
            }
            public List<BoxPlotItem> Data
            {
                get; set;
            }
            public static double GetMedian(IEnumerable<double> values)
            {
                var sortedInterval = new List<double>(values);
                sortedInterval.Sort();
                var count = sortedInterval.Count;
                if (count % 2 == 1)
                {
                    return sortedInterval[(count - 1) / 2];
                }

                return 0.5 * sortedInterval[count / 2] + 0.5 * sortedInterval[(count / 2) - 1];
            }
        }
    }
}
