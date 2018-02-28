using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart
    {
        /// <summary>
        /// Represents a heat map.
        /// </summary>
        public class HeatMap:Series
        {
            /// <summary>
            /// Gets or sets the x-coordinate of the elements at index [0,*] in the data set.
            /// </summary>
            /// <value>
            /// If <see cref="CoordinateDefinition" /> equals <see cref="HeatMapCoordinateDefinition.Center"/>, the value defines the mid point of the element at index [0,*] in the data set.
            /// If <see cref="CoordinateDefinition" /> equals <see cref="HeatMapCoordinateDefinition.Edge"/>, the value defines the coordinate of the left edge of the element at index [0,*] in the data set.
            /// </value>
            public double X0 { get; set; }

            /// <summary>
            /// Gets or sets the x-coordinate of the mid point for the elements at index [m-1,*] in the data set.
            /// </summary>
            /// <value>
            /// If <see cref="CoordinateDefinition" /> equals <see cref="HeatMapCoordinateDefinition.Center"/>, the value defines the mid point of the element at index [m-1,*] in the data set.
            /// If <see cref="CoordinateDefinition" /> equals <see cref="HeatMapCoordinateDefinition.Edge"/>, the value defines the coordinate of the right edge of the element at index [m-1,*] in the data set.
            /// </value>
            public double X1 { get; set; }

            /// <summary>
            /// Gets or sets the y-coordinate of the mid point for the elements at index [*,0] in the data set.
            /// </summary>
            /// <value>
            /// If <see cref="CoordinateDefinition" /> equals <see cref="HeatMapCoordinateDefinition.Center"/>, the value defines the mid point of the element at index [*,0] in the data set.
            /// If <see cref="CoordinateDefinition" /> equals <see cref="HeatMapCoordinateDefinition.Edge"/>, the value defines the coordinate of the bottom edge of the element at index [*,0] in the data set.
            /// </value>
            public double Y0 { get; set; }

            /// <summary>
            /// Gets or sets the y-coordinate of the mid point for the elements at index [*,n-1] in the data set.
            /// </summary>
            /// <value>
            /// If <see cref="CoordinateDefinition" /> equals <see cref="HeatMapCoordinateDefinition.Center"/>, the value defines the mid point of the element at index [*,n-1] in the data set.
            /// If <see cref="CoordinateDefinition" /> equals <see cref="HeatMapCoordinateDefinition.Edge"/>, the value defines the coordinate of the top edge of the element at index [*,n-1] in the data set.
            /// </value>
            public double Y1 { get; set; }

            /// <summary>
            /// Gets or sets the data array.
            /// </summary>
            /// <remarks>Note that the indices of the data array refer to [x,y].
            /// The first dimension is along the x-axis.
            /// The second dimension is along the y-axis.
            /// Remember to call the <see cref="Invalidate" /> method if the contents of the <see cref="Data" /> array is changed.</remarks>
            public double[,] Data { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether to interpolate when rendering. The default value is <c>true</c>.
            /// </summary>
            /// <remarks>This property is not supported on all platforms. Ignored (off) if <see cref="RenderMethod" /> is <see cref="HeatMapRenderMethod.Rectangles" />.</remarks>
            public bool Interpolate { get; set; }
            /// <summary>
            /// Gets or sets the coordinate definition. The default value is <see cref="HeatMapCoordinateDefinition.Center" />.
            /// </summary>
            /// <value>The coordinate definition.</value>
            public HeatMapCoordinateDefinition CoordinateDefinition { get; set; }
            /// <summary>
            /// Gets or sets the render method. The default value is <see cref="HeatMapRenderMethod.Bitmap" />.
            /// </summary>
            /// <value>The render method.</value>
            public HeatMapRenderMethod RenderMethod { get; set; }
        }
    }
}
