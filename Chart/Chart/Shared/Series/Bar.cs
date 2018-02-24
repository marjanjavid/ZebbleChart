using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart
    {
        /// <summary>
        /// Represents a series for clustered or stacked bar charts.
        /// </summary>
        public class Bar : Series
        {
            public Bar()
            {

            }
            public Bar(List<Item> data)
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
