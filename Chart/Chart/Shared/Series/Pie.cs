using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart
    {
        public class Pie: IPlotType
        {
            public List<PieSlice> Data
            {
                get; set;
            }
            public Pie()
            {

            }
            public Pie(List<PieSlice> data)
            {
                this.Data = data;
            }
        }
    }
}
