using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart
    {
        public class HighLow:Series
        {
            

            public HighLow()
            {
                this.Data = new List<HighLowItem>();
            }
            /// <summary>
            /// Gets the items of the series.
            /// </summary>
            /// <value>The items.</value>
            public List<HighLowItem> Data
            {
                get;set;
            }
        }
    }
}
