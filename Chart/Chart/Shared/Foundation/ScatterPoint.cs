using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart
    {
        public class ScatterPoint
        {
            public ScatterPoint()
            {
                    
            }
            public ScatterPoint(double x, double y, double size = double.NaN, double value = double.NaN, object tag = null)
            {
                this.X = x;
                this.Y = y;
                this.Size = size;
                this.Value = value;
                this.Tag = tag;
            }
            /// <summary>
            /// Gets the X.
            /// </summary>
            /// <value>The X.</value>
            public double X { get; private set; }

            /// <summary>
            /// Gets the Y.
            /// </summary>
            /// <value>The Y.</value>
            public double Y { get; private set; }

            /// <summary>
            /// Gets or sets the size.
            /// </summary>
            /// <value>The size.</value>
            public double Size { get; set; }

            /// <summary>
            /// Gets or sets the value.
            /// </summary>
            /// <value>The value.</value>
            public double Value { get; set; }

            /// <summary>
            /// Gets or sets the tag.
            /// </summary>
            /// <value>The tag.</value>
            public object Tag { get; set; }
            public static implicit operator OxyPlot.Series.ScatterPoint(ScatterPoint scatterPoint)
            {
                return new OxyPlot.Series.ScatterPoint(scatterPoint.X, scatterPoint.Y, scatterPoint.Size, scatterPoint.Value, scatterPoint.Tag);
                
            }
        }
    }
}
