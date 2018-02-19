using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart
    {
        /// <summary>
        /// Represents an item used in the ColumnSeries.
        /// </summary>
        public class ColumnItem : IPlotType
        {
            /// <summary>
            /// Gets or sets the value of the item.
            /// </summary>
            public double Value { get; set; }
            /// <summary>
            /// Gets or sets the index of the category.
            /// </summary>
            /// <value>The index of the category.</value>
            public int CategoryIndex { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="ColumnItem" /> class.
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="categoryIndex">Index of the category.</param>
            public ColumnItem(double value, int categoryIndex = -1)
            {
                this.Value = value;
                this.CategoryIndex = categoryIndex;
            }
            public static implicit operator OxyPlot.Series.ColumnItem(ColumnItem columnItem)
            {
                return new OxyPlot.Series.ColumnItem(columnItem.Value, columnItem.CategoryIndex);
            }
        }
    }
}
