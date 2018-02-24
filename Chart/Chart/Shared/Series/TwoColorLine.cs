using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart
    {
        public class TwoColorLine:Line
        {
            /// <summary>
            /// Gets or sets the color for the part of the line that is below the limit.
            /// </summary>
            public Zebble.Color Color2 { get; set; }
            /// <summary>
            /// Gets or sets the limit.
            /// </summary>
            /// <remarks>The parts of the line that is below this limit will be rendered with Color2.
            /// The parts of the line that is above the limit will be rendered with Color.</remarks>
            public double Limit { get; set; }
        }
    }
}
