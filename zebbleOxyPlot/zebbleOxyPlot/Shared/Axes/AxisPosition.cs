using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    partial class zebbleOxyPlot
    {
        /// <summary>
        /// Specifies the position of an <see cref="Axis" />.
        /// </summary>
        public enum AxisPosition
        {
            /// <summary>
            /// No position.
            /// </summary>
            None,

            /// <summary>
            /// Left of the plot area.
            /// </summary>
            Left,

            /// <summary>
            /// Right of the plot area.
            /// </summary>
            Right,

            /// <summary>
            /// Top of the plot area.
            /// </summary>
            Top,

            /// <summary>
            /// Bottom of the plot area.
            /// </summary>
            Bottom
        }
    }
}
