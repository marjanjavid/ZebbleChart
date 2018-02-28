using OxyPlot.Axes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart
    {
        public class Axis
        {
            /// <summary>
            /// Gets or sets the title of the axis. The default value is <c>null</c>.
            /// </summary>
            public string Title { get; set; }
            /// <summary>
            /// Gets or sets the position of the axis. The default value is <see cref="AxisPosition.Left"/>.
            /// </summary>
            //TODO: ask mr mohseni about implementing these kind of classes or use oxyplot itself
            public AxisPosition Position
            {
                get
                {
                    return this.position;
                }

                set
                {
                    this.position = value;
                }
            }
            /// <summary>
            /// Gets or sets the unit of the axis. The default value is <c>null</c>.
            /// </summary>
            /// <remarks>The <see cref="TitleFormatString" /> is used to format the title including this unit.</remarks>
            public string Unit { get; set; }
            /// <summary>
            /// The position of the axis.
            /// </summary>
            private AxisPosition position;
        }
    }
}
