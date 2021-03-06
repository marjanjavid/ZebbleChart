﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart
    {
        /// <summary>
        /// Represents an item in a <see cref="HighLowSeries" />.
        /// </summary>
        public class HighLowItem 
        {
            /// <summary>
            /// The undefined.
            /// </summary>
            public static readonly HighLowItem Undefined = new HighLowItem(double.NaN, double.NaN, double.NaN);

            /// <summary>
            /// Initializes a new instance of the <see cref="HighLowItem" /> class.
            /// </summary>
            public HighLowItem()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="HighLowItem"/> class.
            /// </summary>
            /// <param name="xx">
            /// The xx value.
            /// </param>
            /// <param name="high">
            /// The high value.
            /// </param>
            /// <param name="low">
            /// The low value.
            /// </param>
            /// <param name="open">
            /// The open value.
            /// </param>
            /// <param name="close">
            /// The close value.
            /// </param>
            public HighLowItem(double xx, double high, double low, double open = double.NaN, double close = double.NaN)
            {
                this.X = xx;
                this.High = high;
                this.Low = low;
                this.Open = open;
                this.Close = close;
            }

            /// <summary>
            /// Gets or sets the close value.
            /// </summary>
            /// <value>The close value.</value>
            public double Close { get; set; }

            /// <summary>
            /// Gets or sets the high value.
            /// </summary>
            /// <value>The high value.</value>
            public double High { get; set; }

            /// <summary>
            /// Gets or sets the low value.
            /// </summary>
            /// <value>The low value.</value>
            public double Low { get; set; }

            /// <summary>
            /// Gets or sets the open value.
            /// </summary>
            /// <value>The open value.</value>
            public double Open { get; set; }

            /// <summary>
            /// Gets or sets the X value (time).
            /// </summary>
            /// <value>The X value.</value>
            public double X { get; set; }

            public static implicit operator OxyPlot.Series.HighLowItem(HighLowItem highLowItem)
            {
                return new OxyPlot.Series.HighLowItem()
                {
                    Close=highLowItem.Close,
                    High=highLowItem.High,
                    Low=highLowItem.Low,
                    Open=highLowItem.Open,
                    X=highLowItem.X
                };
            }
        }
    }
}
