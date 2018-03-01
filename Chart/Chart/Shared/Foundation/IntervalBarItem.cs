using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public class IntervalBarItem
    {
        /// <summary>
        /// Gets or sets the end value.
        /// </summary>
        public double End { get; set; }

        /// <summary>
        /// Gets or sets the start value.
        /// </summary>
        public double Start { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
        public static implicit operator OxyPlot.Series.IntervalBarItem(IntervalBarItem intervalBarItem)
        {
            return new OxyPlot.Series.IntervalBarItem
            {
                Title = intervalBarItem.Title,
                Start = intervalBarItem.Start,
                End = intervalBarItem.End
            };
        }
    }
}
