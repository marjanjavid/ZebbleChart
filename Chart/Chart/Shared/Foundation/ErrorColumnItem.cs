using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart
    {
        /// <summary>
        /// Represents an item used in the ErrorColumnSeries.
        /// </summary>
        public class ErrorColumnItem:Item
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ErrorColumnItem" /> class.
            /// </summary>
            public ErrorColumnItem()
            {

            }

            /// <summary>
            /// Initializes a new instance of the <see cref="ErrorColumnItem" /> class.
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="error">The error.</param>
            /// <param name="categoryIndex">Index of the category.</param>
            public ErrorColumnItem(double value, double error, int categoryIndex = -1)
                : this()
            {
                this.Value = value;
                this.Error = error;
                this.CategoryIndex = categoryIndex;
            }

            /// <summary>
            /// Gets or sets the error of the item.
            /// </summary>
            public double Error { get; set; }

            public static explicit operator OxyPlot.Series.ErrorColumnItem(ErrorColumnItem errorColumnItem)
            {
                return new OxyPlot.Series.ErrorColumnItem(errorColumnItem.Value,errorColumnItem.Error, errorColumnItem.CategoryIndex !=0? errorColumnItem.CategoryIndex:-1);
            }
        }
    }
}
