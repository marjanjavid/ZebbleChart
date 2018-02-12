using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    partial class zebbleOxyPlot
    {
        /// <summary>
        /// Defines the mode of selection used by <see cref="SelectableElement" />.
        /// </summary>
        public enum SelectionMode
        {
            /// <summary>
            /// All the elements will be selected
            /// </summary>
            All,

            /// <summary>
            /// A single element will be selected
            /// </summary>
            Single,

            /// <summary>
            /// Multiple elements can be selected
            /// </summary>
            Multiple
        }
    }
}