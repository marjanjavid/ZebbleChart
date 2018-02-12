using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    partial class zebbleOxyPlot
    {
        /// <summary>
        /// Provides data for the mouse events.
        /// </summary>
        public class OxyMouseEventArgs : OxyInputEventArgs
        {
            /// <summary>
            /// Gets or sets the position of the mouse cursor.
            /// </summary>
            public ScreenPoint Position { get; set; }
        }
    }
}