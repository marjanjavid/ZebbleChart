using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    partial class zebbleOxyPlot
    {
        /// <summary>
        /// Defines the style of axis ticks.
        /// </summary>
        public enum TickStyle
        {
            /// <summary>
            /// The ticks are rendered crossing the axis line.
            /// </summary>
            Crossing,

            /// <summary>
            /// The ticks are rendered inside of the plot area.
            /// </summary>
            Inside,

            /// <summary>
            /// The ticks are rendered Outside the plot area.
            /// </summary>
            Outside,

            /// <summary>
            /// The ticks are not rendered.
            /// </summary>
            None
        }
    }
}
