using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart
    {
        public class CandleStick:Series
        {
            public CandleStick()
            {
                this.Data = new List<HighLowItem>();
            }
            public CandleStick(List<HighLowItem> data)
            {
                this.Data = data;
            }
            public List<HighLowItem> Data
            {
                get; set;
            }
        }
    }
}
