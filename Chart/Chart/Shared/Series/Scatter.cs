using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart
    {
        /// <summary>
        /// Provides a base class for scatter series.
        /// </summary>
        public class Scatter:Series
        {
            public Scatter()
            {
                this.Data = new List<ScatterPoint>();
            }
            public List<ScatterPoint> Data { get; set; }
        }
    }
}
