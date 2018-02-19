using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart
    {
        public class Line:IPlotType
        {
            public List<DataPoint> Data
            {
                get; set;
            }
            public Line()
            {
                
            }
            public Line(List<DataPoint> data)
            {
                this.Data = data;
            }
        }
    }
}
