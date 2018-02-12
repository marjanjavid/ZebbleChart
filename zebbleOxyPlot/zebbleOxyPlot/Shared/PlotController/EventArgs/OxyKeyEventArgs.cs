using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    partial class zebbleOxyPlot
    {
        /// <summary>
        /// Provides data for key events.
        /// </summary>
        public class OxyKeyEventArgs : OxyInputEventArgs
        {
            /// <summary>
            /// Gets or sets the key.
            /// </summary>
            public OxyKey Key { get; set; }
        }
    }
}