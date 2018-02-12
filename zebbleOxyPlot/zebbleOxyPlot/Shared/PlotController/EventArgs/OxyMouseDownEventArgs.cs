using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    partial class zebbleOxyPlot
    {
        /// <summary>
        /// Provides data for the mouse down events.
        /// </summary>
        public class OxyMouseDownEventArgs : OxyMouseEventArgs
        {
            /// <summary>
            /// Gets or sets the mouse button that has changed.
            /// </summary>
            public OxyMouseButton ChangedButton { get; set; }

            /// <summary>
            /// Gets or sets the number of times the button was clicked.
            /// </summary>
            /// <value>The number of times the mouse button was clicked.</value>
            public int ClickCount { get; set; }

            /// <summary>
            /// Gets or sets the hit test result.
            /// </summary>
            public HitTestResult HitTestResult { get; set; } // TODO: REMOVE THIS?
        }
    }
}