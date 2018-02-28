using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart
    {
        public class Area : Series
        {
            public Area(List<DataPoint> data)
            {
                this.Data = data;
            }
            public Area()
            {
                this.Data = new List<DataPoint>();
            }
            /// <summary>
            /// Gets or sets line color.
            /// </summary>
            public Zebble.Color Color { get; set; }
            /// <summary>
            /// Gets or sets the color of the line for the second data set.
            /// </summary>
            /// <value>The color.</value>
            public Zebble.Color Color2 { get; set; }
            public List<DataPoint> Data
            {
                get;set;
            }
            
        }
    }
}
