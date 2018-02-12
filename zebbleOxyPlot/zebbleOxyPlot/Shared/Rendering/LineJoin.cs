using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    partial class zebbleOxyPlot
    {
        /// <summary>
        /// Defines how to join line segments.
        /// </summary>
        public enum LineJoin
        {
            /// <summary>
            /// Line joins use regular angular vertices.
            /// </summary>
            Miter,

            /// <summary>
            /// Line joins use rounded vertices.
            /// </summary>
            Round,

            /// <summary>
            /// Line joins use beveled vertices.
            /// </summary>
            Bevel
        }
    }
}