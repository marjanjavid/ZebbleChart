using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart
    {
        public class PieSlice
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="PieSlice" /> class.
            /// </summary>
            /// <param name="label">The label.</param>
            /// <param name="value">The value.</param>
            public PieSlice(string label, double value)
            {
                this.Label = label;
                this.Value = value;
            }
            
            /// <summary>
            /// Gets the label.
            /// </summary>
            public string Label { get; private set; }

            /// <summary>
            /// Gets the value.
            /// </summary>
            public double Value { get; private set; }
            public static implicit operator OxyPlot.Series.PieSlice(PieSlice slice)
            {
                var oxyplotdatapoint = new OxyPlot.Series.PieSlice(slice.Label, slice.Value);
                return oxyplotdatapoint;
            }
        }
    }
}
