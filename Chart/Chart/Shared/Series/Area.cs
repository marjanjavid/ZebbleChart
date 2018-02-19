using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart
    {
        public class Area : IPlotType
        {
             public List<DataPoint> Data
            {
                get;set;
            }
            public Area(List<DataPoint> data)
            {
                this.Data = data;
            }
            public Area()
            {

            }
        }
    }
}
