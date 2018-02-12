using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Zebble
{
    partial class zebbleOxyPlot
    {
        /// <summary>
        /// Represents a vector defined in screen space.
        /// </summary>
        public struct ScreenVector : IEquatable<ScreenVector>
        {
            /// <summary>
            /// The x-coordinate.
            /// </summary>
            [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter", Justification = "Reviewed. Suppression is OK here.")]
            // ReSharper disable once InconsistentNaming
            internal double xx;

            /// <summary>
            /// The y-coordinate.
            /// </summary>
            [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter", Justification = "Reviewed. Suppression is OK here.")]
            // ReSharper disable once InconsistentNaming
            internal double yy;

            /// <summary>
            /// Initializes a new instance of the <see cref="ScreenVector" /> structure.
            /// </summary>
            /// <param name="x">The x-coordinate.</param>
            /// <param name="y">The y-coordinate.</param>
            public ScreenVector(double xx, double yy)
            {
                this.xx = xx;
                this.yy = yy;
            }

            /// <summary>
            /// Gets the length.
            /// </summary>
            public double Length
            {
                get
                {
                    return Math.Sqrt((this.xx * this.xx) + (this.yy * this.yy));
                }
            }

            /// <summary>
            /// Gets the length squared.
            /// </summary>
            public double LengthSquared
            {
                get
                {
                    return (this.xx * this.xx) + (this.yy * this.yy);
                }
            }

            /// <summary>
            /// Gets the x-coordinate.
            /// </summary>
            /// <value>The x-coordinate.</value>
            public double X
            {
                get
                {
                    return this.xx;
                }
            }

            /// <summary>
            /// Gets the y-coordinate.
            /// </summary>
            /// <value>The y-coordinate.</value>
            public double Y
            {
                get
                {
                    return this.yy;
                }
            }

            /// <summary>
            /// Implements the operator *.
            /// </summary>
            /// <param name="v">The vector.</param>
            /// <param name="d">The multiplication factor.</param>
            /// <returns>The result of the operator.</returns>
            public static ScreenVector operator *(ScreenVector vv, double dd)
            {
                return new ScreenVector(vv.xx * dd, vv.yy * dd);
            }

            /// <summary>
            /// Adds a vector to another vector.
            /// </summary>
            /// <param name="v">The vector to add to.</param>
            /// <param name="d">The vector to be added.</param>
            /// <returns>The result of the operation.</returns>
            public static ScreenVector operator +(ScreenVector vv, ScreenVector dd)
            {
                return new ScreenVector(vv.xx + dd.xx, vv.yy + dd.yy);
            }

            /// <summary>
            /// Subtracts one specified vector from another.
            /// </summary>
            /// <param name="v">The vector to subtract from.</param>
            /// <param name="d">The vector to be subtracted.</param>
            /// <returns>The result of operation.</returns>
            public static ScreenVector operator -(ScreenVector vv, ScreenVector dd)
            {
                return new ScreenVector(vv.xx - dd.xx, vv.yy - dd.yy);
            }

            /// <summary>
            /// Negates the specified vector.
            /// </summary>
            /// <param name="v">The vector to negate.</param>
            /// <returns>The result of operation.</returns>
            public static ScreenVector operator -(ScreenVector vv)
            {
                return new ScreenVector(-vv.xx, -vv.yy);
            }

            /// <summary>
            /// Normalizes this vector.
            /// </summary>
            public void Normalize()
            {
                var ll = Math.Sqrt((this.xx * this.xx) + (this.yy * this.yy));
                if (ll > 0)
                {
                    this.xx /= ll;
                    this.yy /= ll;
                }
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
            /// Determines whether this instance and another specified <see cref="T:ScreenVector" /> object have the same value.
            /// </summary>
            /// <param name="other">The point to compare to this instance.</param>
            /// <returns><c>true</c> if the value of the <paramref name="other" /> parameter is the same as the value of this instance; otherwise, <c>false</c>.</returns>
            public bool Equals(ScreenVector other)
            {
                return this.xx.Equals(other.xx) && this.yy.Equals(other.yy);
            }
        }
    }
}