using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart
    {
        public class Line: Series
        {
            public Line()
            {
                this.Data = new List<DataPoint>();
            }
            public Line(List<DataPoint> data)
            {
                this.Data = data;
            }
            /// <summary>
            /// Gets or sets the color of the curve.
            /// </summary>
            /// <value>The color.</value>
            public Zebble.Color Color { get; set; }
            public List<DataPoint> Data
            {
                get; set;
            }
            
        }
    }
}
