﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Zebble
{
    partial class zebbleOxyPlot
    {
        /// <summary>
        /// Represents a point in the data space.
        /// </summary>
        /// <remarks><see cref="DataPoint" />s are transformed to <see cref="ScreenPoint" />s.</remarks>
        public struct DataPoint : ICodeGenerating, IEquatable<DataPoint>
        {
            /// <summary>
            /// The undefined.
            /// </summary>
            public static readonly DataPoint Undefined = new DataPoint(double.NaN, double.NaN);

            /// <summary>
            /// The x-coordinate.
            /// </summary>
            [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter",
                Justification = "Reviewed. Suppression is OK here.")]
            internal readonly double xx;

            /// <summary>
            /// The y-coordinate.
            /// </summary>
            [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter",
                Justification = "Reviewed. Suppression is OK here.")]
            internal readonly double yy;

            /// <summary>
            /// Initializes a new instance of the <see cref="DataPoint" /> struct.
            /// </summary>
            /// <param name="x">The x.</param>
            /// <param name="y">The y.</param>
            public DataPoint(double xx, double yy)
            {
                this.xx = xx;
                this.yy = yy;
            }

            /// <summary>
            /// Gets the X-coordinate of the point.
            /// </summary>
            /// <value>The X-coordinate.</value>
            public double X
            {
                get
                {
                    return this.xx;
                }
            }

            /// <summary>
            /// Gets the Y-coordinate of the point.
            /// </summary>
            /// <value>The Y-coordinate.</value>
            public double Y
            {
                get
                {
                    return this.yy;
                }
            }

            /// <summary>
            /// Returns C# code that generates this instance.
            /// </summary>
            /// <returns>The to code.</returns>
            public string ToCode()
            {
                return CodeGenerator.FormatConstructor(this.GetType(), "{0},{1}", this.xx, this.yy);
            }

            /// <summary>
            /// Determines whether this instance and another specified <see cref="T:DataPoint" /> object have the same value.
            /// </summary>
            /// <param name="other">The point to compare to this instance.</param>
            /// <returns><c>true</c> if the value of the <paramref name="other" /> parameter is the same as the value of this instance; otherwise, <c>false</c>.</returns>
            public bool Equals(DataPoint other)
            {
                return this.xx.Equals(other.xx) && this.yy.Equals(other.yy);
            }

            /// <summary>
            /// Returns a <see cref="System.String" /> that represents this instance.
            /// </summary>
            /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
            public override string ToString()
            {
                return this.xx + " " + this.yy;
            }

            /// <summary>
            /// Determines whether this point is defined.
            /// </summary>
            /// <returns><c>true</c> if this point is defined; otherwise, <c>false</c>.</returns>
            public bool IsDefined()
            {
                // check that x and y is not NaN (the code below is faster than double.IsNaN)
#pragma warning disable 1718
                // ReSharper disable EqualExpressionComparison
                // ReSharper disable CompareOfFloatsByEqualityOperator
                return this.xx == this.xx && this.yy == this.yy;
                // ReSharper restore CompareOfFloatsByEqualityOperator
                // ReSharper restore EqualExpressionComparison
#pragma warning restore 1718
            }
        }
    }
}