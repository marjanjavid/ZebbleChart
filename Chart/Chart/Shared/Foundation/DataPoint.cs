using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace Zebble
{
    public partial class Chart
    {
        /// <summary>
        /// Represents a point in the data space.
        /// </summary>
        /// <remarks><see cref="DataPoint" />s are transformed to <see cref="ScreenPoint" />s.</remarks>
        public struct DataPoint
        {
            /// <summary>
            /// The undefined.
            /// </summary>
            public static readonly DataPoint Undefined = new DataPoint(double.NaN, double.NaN);

            /// <summary>
            /// The x-coordinate.
            /// </summary>
            [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter",
                Justification = "Reviewed. Suppression is OK here.")]
            internal readonly double xx;

            /// <summary>
            /// The y-coordinate.
            /// </summary>
            [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter",
                Justification = "Reviewed. Suppression is OK here.")]
            internal readonly double yy;

            /// <summary>
            /// Initializes a new instance of the <see cref="DataPoint" /> struct.
            /// </summary>
            /// <param name="x">The x.</param>
            /// <param name="y">The y.</param>
            public DataPoint(double xx, double yy)
            {
                this.xx = xx;
                this.yy = yy;
            }

            /// <summary>
            /// Gets the X-coordinate of the point.
            /// </summary>
            /// <value>The X-coordinate.</value>
            public double X
            {
                get
                {
                    return this.xx;
                }
            }

            /// <summary>
            /// Gets the Y-coordinate of the point.
            /// </summary>
            /// <value>The Y-coordinate.</value>
            public double Y
            {
                get
                {
                    return this.yy;
                }
            }



            public static implicit operator OxyPlot.DataPoint(DataPoint datapoint)
            {
                var oxyplotdatapoint = new OxyPlot.DataPoint(datapoint.X, datapoint.Y);
                return oxyplotdatapoint;
            }
        }
    }
}
