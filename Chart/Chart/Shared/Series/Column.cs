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
        public class Column : Series
        {
            public Column()
            {
                this.Data = new List<Item>();
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
