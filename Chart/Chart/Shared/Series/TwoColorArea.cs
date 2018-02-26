using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart
    {
        public class TwoColorArea : Area
        {

            /// <summary>
            /// Gets or sets a baseline for the series.
            /// </summary>
            public double Limit { get; set; }
        }
    }
}
