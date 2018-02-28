using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart
    {
        /// <summary>
        /// Represents a line series that generates its dataset from a function.
        /// </summary>
        /// <remarks>Define <code>f(x)</code> and make a plot on the range <code>[x0,x1]</code> or define <code>x(t)</code> and <code>y(t)</code> and make a plot on the range <code>[t0,t1]</code>.</remarks>
        public class Function : Line
        {
            /// <summary>
            /// Initializes a new instance of the <see cref = "Function" /> class.
            /// </summary>
            public Function()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Function" /> class using a function <code>f(x)</code>.
            /// </summary>
            /// <param name="ff">The function <code>f(x)</code>.</param>
            /// <param name="x0">The start x value.</param>
            /// <param name="x1">The end x value.</param>
            /// <param name="dx">The increment in x.</param>
            /// <param name="title">The title (optional).</param>
            public Function(Func<double, double> ff, double x0, double x1, double dx, string title = null)
            {
                this.Title = title;
                for (double x = x0; x <= x1 + (dx * 0.5); x += dx)
                {
                    this.Data.Add(new DataPoint(x, ff(x)));
                }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Function" /> class using a function <code>f(x)</code>.
            /// </summary>
            /// <param name="ff">The function <code>f(x)</code>.</param>
            /// <param name="x0">The start x value.</param>
            /// <param name="x1">The end x value.</param>
            /// <param name="nn">The number of points.</param>
            /// <param name="title">The title (optional).</param>
            public Function(Func<double, double> ff, double x0, double x1, int nn, string title = null)
                : this(ff, x0, x1, (x1 - x0) / (nn - 1), title)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Function" /> class using functions <code>x(t)</code> and <code>y(t)</code>.
            /// </summary>
            /// <param name="fx">The function <code>x(t)</code>.</param>
            /// <param name="fy">The function <code>y(t)</code>.</param>
            /// <param name="t0">The start t parameter.</param>
            /// <param name="t1">The end t parameter.</param>
            /// <param name="dt">The increment in t.</param>
            /// <param name="title">The title.</param>
            public Function(Func<double, double> fx, Func<double, double> fy, double t0, double t1, double dt, string title = null)
            {
                this.Title = title;
                for (double t = t0; t <= t1 + (dt * 0.5); t += dt)
                {
                    this.Data.Add(new DataPoint(fx(t), fy(t)));
                }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Function" /> class using functions <code>x(t)</code> and <code>y(t)</code>.
            /// </summary>
            /// <param name="fx">The function <code>x(t)</code>.</param>
            /// <param name="fy">The function <code>y(t)</code>.</param>
            /// <param name="t0">The start t parameter.</param>
            /// <param name="t1">The end t parameter.</param>
            /// <param name="nn">The number of points.</param>
            /// <param name="title">The title.</param>
            public Function(
                Func<double, double> fx, Func<double, double> fy, double t0, double t1, int nn, string title = null)
                : this(fx, fy, t0, t1, (t1 - t0) / (nn - 1), title)
            {
            }
        }
    }
}
