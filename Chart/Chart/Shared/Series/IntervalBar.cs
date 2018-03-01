using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart
    {
        /// <summary>
        /// Represents a series for bar charts defined by to/from values.
        /// </summary>
        public class IntervalBar:Series
        {
            public IntervalBar()
            {
                this.Data = new List<IntervalBarItem>();
            }
            public List<IntervalBarItem> Data { get; set; }
        }
    }
}
