using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    partial class zebbleOxyPlot
    {
        public abstract class Element
        {
            /// <summary>
            /// Gets the parent model of the element.
            /// </summary>
            /// <value>
            /// The <see cref="Model" /> that is the parent of the element.
            /// </value>
            public Model Parent { get; internal set; }
        }
    }
}