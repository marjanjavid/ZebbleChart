using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart
    {
        /// <summary>
        /// Represents a series for clustered or stacked Column charts.
        /// </summary>
        public class Column : IPlotType
        {
            public Column()
            {

            }
            public Column(List<Item> data)
            {
                this.Data = data;
            }
            public List<Item> Data
            {
                get; set;
            }


        }
    }
}
