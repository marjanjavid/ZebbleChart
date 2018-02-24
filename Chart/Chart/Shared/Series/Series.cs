using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart
    {
        public class Series
        {
            /// <summary>
            /// Gets or sets the title of the series. The default is <c>null</c>.
            /// </summary>
            /// <value>The title that is shown in the legend of the plot. The default value is <c>null</c>.</value>
            public string Title { get; set; }
        }
    }
}
