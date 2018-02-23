using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart
    {
        /// <summary>
        /// Represents a rectangle item in a RectangleBarSeries.
        /// </summary>
        public class RectangleBarItem
        {
            public RectangleBarItem()
            {

            }
            /// <summary>
            /// Initializes a new instance of the <see cref="RectangleBarItem" /> class.
            /// </summary>
            /// <param name="x0">The x0.</param>
            /// <param name="y0">The y0.</param>
            /// <param name="x1">The x1.</param>
            /// <param name="y1">The y1.</param>
            public RectangleBarItem(double x0, double y0, double x1, double y1)
                : this()
            {
                this.X0 = x0;
                this.Y0 = y0;
                this.X1 = x1;
                this.Y1 = y1;
            }
            /// <summary>
            /// Gets or sets the title.
            /// </summary>
            public string Title { get; set; }
            /// <summary>
            /// Gets or sets the x0 coordinate.
            /// </summary>
            public double X0 { get; set; }

            /// <summary>
            /// Gets or sets the x1 coordinate.
            /// </summary>
            public double X1 { get; set; }

            /// <summary>
            /// Gets or sets the y0 coordinate.
            /// </summary>
            public double Y0 { get; set; }

            /// <summary>
            /// Gets or sets the y1 coordinate.
            /// </summary>
            public double Y1 { get; set; }

            public static implicit operator OxyPlot.Series.RectangleBarItem(RectangleBarItem rectangleBarItem)
            {
                return new OxyPlot.Series.RectangleBarItem()
                {
                    Title = rectangleBarItem.Title,
                    X0 = rectangleBarItem.X0,
                    X1 = rectangleBarItem.X1,
                    Y0 = rectangleBarItem.Y0,
                    Y1 = rectangleBarItem.Y1
                };
            }
        }
    }
}
