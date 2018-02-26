using System;
using System.Collections.Generic;
using System.Text;
using OxyPlot;

namespace Zebble
{
    public partial class Chart
    {
        public class ChartColor
        {
            /// <summary>
            /// Parse a string.
            /// </summary>
            /// <param name="value">The string in the format <c>"#FFFFFF00"</c> or <c>"255,200,180,50"</c>.</param>
            /// <returns>The parsed color.</returns>
            /// <exception cref="System.FormatException">Invalid format.</exception>
            public string StringColor { get; set; }
            /// <summary>
            /// Convert an <see cref="uint" /> to a <see cref="OxyColor" />.
            /// </summary>
            /// <param name="color">The unsigned integer color value.</param>
            /// <returns>The <see cref="OxyColor" />.</returns>
            public uint UintColor { get; set; }

            public Zebble.Color zebbleColor { get; set; }
            //public static implicit operator OxyColor(Color chartColor)
            //{
            //    if (!string.IsNullOrEmpty(chartColor.StringColor))
            //        return OxyColor.Parse(chartColor.StringColor);
            //    if (chartColor.UintColor != 0)
            //        return OxyColor.FromUInt32(chartColor.UintColor);
            //    if (chartColor.zebbleColor != null)
            //        return OxyColor.FromArgb(chartColor.zebbleColor.Alpha, chartColor.zebbleColor.Red, chartColor.zebbleColor.Green, chartColor.zebbleColor.Blue);
            //    return new OxyColor();
            //}
            public static OxyColor CastToOxyColor(Zebble.Color chartColor)
            {
                
                if (chartColor != null)
                    return OxyColor.FromArgb(chartColor.Alpha, chartColor.Red, chartColor.Green, chartColor.Blue);
                return new OxyColor();
            }
        }
    }

}
