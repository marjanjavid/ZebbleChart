using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart
    {
        public class Contour:Series
        {
            public Contour()
            {

            }
            public Contour(double[,] data)
            {
                this.Data = data;
            }
            
            /// <summary>
            /// Gets or sets the data.
            /// </summary>
            /// <value>The data.</value>
            public double[,] Data { get; set; }
            /// <summary>
            /// Gets or sets the column coordinates.
            /// </summary>
            /// <value>The column coordinates.</value>
            public double[] ColumnCoordinates { get; set; }
            /// <summary>
            /// Gets or sets the row coordinates.
            /// </summary>
            /// <value>The row coordinates.</value>
            public double[] RowCoordinates { get; set; }
        }
    }
}
