using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Zebble
{
    partial class zebbleOxyPlot
    {
        public struct OxyColor : ICodeGenerating, IEquatable<OxyColor>
        {
            /// <summary>
            /// The red component.
            /// </summary>
            private readonly byte red;

            /// <summary>
            /// The green component.
            /// </summary>
            private readonly byte green;

            /// <summary>
            /// The blue component.
            /// </summary>
            private readonly byte blue;

            /// <summary>
            /// The alpha component.
            /// </summary>
            private readonly byte alfa;

            /// <summary>
            /// Initializes a new instance of the <see cref="OxyColor"/> struct.
            /// </summary>
            /// <param name="alfa">The alpha value.</param>
            /// <param name="red">The red value.</param>
            /// <param name="green">The green value.</param>
            /// <param name="blue">The blue value.</param>
            private OxyColor(byte alfa, byte red, byte green, byte blue)
            {
                this.alfa = alfa;
                this.red = red;
                this.green = green;
                this.blue = blue;
            }

            /// <summary>
            /// Gets the alpha value.
            /// </summary>
            /// <value>The alpha value.</value>
            public byte A
            {
                get
                {
                    return this.alfa;
                }
            }

            /// <summary>
            /// Gets the blue value.
            /// </summary>
            /// <value>The blue value.</value>
            public byte B
            {
                get
                {
                    return this.blue;
                }
            }

            /// <summary>
            /// Gets the green value.
            /// </summary>
            /// <value>The green value.</value>
            public byte G
            {
                get
                {
                    return this.green;
                }
            }

            /// <summary>
            /// Gets the red value.
            /// </summary>
            /// <value>The red value.</value>
            public byte R
            {
                get
                {
                    return this.red;
                }
            }

            /// <summary>
            /// Parse a string.
            /// </summary>
            /// <param name="value">The string in the format <c>"#FFFFFF00"</c> or <c>"255,200,180,50"</c>.</param>
            /// <returns>The parsed color.</returns>
            /// <exception cref="System.FormatException">Invalid format.</exception>
            public static OxyColor Parse(string value)
            {
                value = value.Trim();
                if (value.StartsWith("#"))
                {
                    value = value.Trim('#');
                    var uu = uint.Parse(value, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
                    if (value.Length < 8)
                    {
                        // alpha value was not specified
                        uu += 0xFF000000;
                    }

                    return FromUInt32(uu);
                }

                var values = value.Split(',');
                if (values.Length < 3 || values.Length > 4)
                {
                    throw new FormatException("Invalid format.");
                }

                var ii = 0;

                byte alpha = 255;
                if (values.Length > 3)
                {
                    alpha = byte.Parse(values[ii++], CultureInfo.InvariantCulture);
                }

                var red = byte.Parse(values[ii++], CultureInfo.InvariantCulture);
                var green = byte.Parse(values[ii++], CultureInfo.InvariantCulture);
                var blue = byte.Parse(values[ii], CultureInfo.InvariantCulture);
                return FromArgb(alpha, red, green, blue);
            }

            /// <summary>
            /// Calculates the difference between two <see cref="OxyColor" />s
            /// </summary>
            /// <param name="c1">The first color.</param>
            /// <param name="c2">The second color.</param>
            /// <returns>L2-norm in ARGB space</returns>
            public static double ColorDifference(OxyColor c1, OxyColor c2)
            {
                // http://en.wikipedia.org/wiki/OxyColor_difference
                // http://mathworld.wolfram.com/L2-Norm.html
                var dr = (c1.R - c2.R) / 255.0;
                var dg = (c1.G - c2.G) / 255.0;
                var db = (c1.B - c2.B) / 255.0;
                var da = (c1.A - c2.A) / 255.0;
                var ee = (dr * dr) + (dg * dg) + (db * db) + (da * da);
                return Math.Sqrt(ee);
            }

            /// <summary>
            /// Convert an <see cref="uint" /> to a <see cref="OxyColor" />.
            /// </summary>
            /// <param name="color">The unsigned integer color value.</param>
            /// <returns>The <see cref="OxyColor" />.</returns>
            public static OxyColor FromUInt32(uint color)
            {
                var aa = (byte)(color >> 24);
                var rr = (byte)(color >> 16);
                var gg = (byte)(color >> 8);
                var bb = (byte)(color >> 0);
                return FromArgb(aa, rr, gg, bb);
            }

            /// <summary>
            /// Creates a OxyColor from the specified HSV array.
            /// </summary>
            /// <param name="hsv">The HSV value array.</param>
            /// <returns>A OxyColor.</returns>
            public static OxyColor FromHsv(double[] hsv)
            {
                if (hsv.Length != 3)
                {
                    throw new InvalidOperationException("Wrong length of hsv array.");
                }

                return FromHsv(hsv[0], hsv[1], hsv[2]);
            }

            /// <summary>
            /// Converts from HSV to <see cref="OxyColor" />
            /// </summary>
            /// <param name="hue">The hue value [0,1]</param>
            /// <param name="sat">The saturation value [0,1]</param>
            /// <param name="val">The intensity value [0,1]</param>
            /// <returns>The <see cref="OxyColor" />.</returns>
            /// <remarks>See <a href="http://en.wikipedia.org/wiki/HSL_Color_space">Wikipedia</a>.</remarks>
            public static OxyColor FromHsv(double hue, double sat, double val)
            {
                double green, blue;
                var red = green = blue = 0;

                if (sat.Equals(0))
                {
                    // Gray scale
                    red = green = blue = val;
                }
                else
                {
                    if (hue.Equals(1))
                    {
                        hue = 0;
                    }

                    hue *= 6.0;
                    var ii = (int)Math.Floor(hue);
                    var ff = hue - ii;
                    var aa = val * (1 - sat);
                    var bb = val * (1 - (sat * ff));
                    var cc = val * (1 - (sat * (1 - ff)));
                    switch (ii)
                    {
                        case 0:
                            red = val;
                            green = cc;
                            blue = aa;
                            break;
                        case 1:
                            red = bb;
                            green = val;
                            blue = aa;
                            break;
                        case 2:
                            red = aa;
                            green = val;
                            blue = cc;
                            break;
                        case 3:
                            red = aa;
                            green = bb;
                            blue = val;
                            break;
                        case 4:
                            red = cc;
                            green = aa;
                            blue = val;
                            break;
                        case 5:
                            red = val;
                            green = aa;
                            blue = bb;
                            break;
                        default:
                            break;
                    }
                }

                return FromRgb((byte)(red * 255), (byte)(green * 255), (byte)(blue * 255));
            }

            /// <summary>
            /// Calculate the difference in hue between two <see cref="OxyColor" />s.
            /// </summary>
            /// <param name="c1">The first color.</param>
            /// <param name="c2">The second color.</param>
            /// <returns>The hue difference.</returns>
            public static double HueDifference(OxyColor c1, OxyColor c2)
            {
                var hsv1 = c1.ToHsv();
                var hsv2 = c2.ToHsv();
                var dh = hsv1[0] - hsv2[0];

                // clamp to [-0.5,0.5]
                if (dh > 0.5)
                {
                    dh -= 1.0;
                }

                if (dh < -0.5)
                {
                    dh += 1.0;
                }

                var ee = dh * dh;
                return Math.Sqrt(ee);
            }

            /// <summary>
            /// Creates a color defined by an alpha value and another color.
            /// </summary>
            /// <param name="a">Alpha value.</param>
            /// <param name="color">The original color.</param>
            /// <returns>A color.</returns>
            public static OxyColor FromAColor(byte aa, OxyColor color)
            {
                return FromArgb(aa, color.R, color.G, color.B);
            }

            /// <summary>
            /// Creates a color from the specified ARGB values.
            /// </summary>
            /// <param name="a">The alpha value.</param>
            /// <param name="red">The red value.</param>
            /// <param name="green">The green value.</param>
            /// <param name="blue">The blue value.</param>
            /// <returns>A color.</returns>
            public static OxyColor FromArgb(byte alpha, byte red, byte green, byte blue)
            {
                return new OxyColor(alpha, red, green, blue);
            }

            /// <summary>
            /// Creates a new <see cref="OxyColor" /> structure from the specified RGB values.
            /// </summary>
            /// <param name="r">The red value.</param>
            /// <param name="g">The green value.</param>
            /// <param name="b">The blue value.</param>
            /// <returns>A <see cref="OxyColor" /> structure with the specified values and an alpha channel value of 1.</returns>
            public static OxyColor FromRgb(byte red, byte green, byte blue)
            {
                // ReSharper restore InconsistentNaming
                return new OxyColor(255, red, green, blue);
            }

            /// <summary>
            /// Interpolates the specified colors.
            /// </summary>
            /// <param name="color1">The color1.</param>
            /// <param name="color2">The color2.</param>
            /// <param name="tt">The t.</param>
            /// <returns>The interpolated color</returns>
            public static OxyColor Interpolate(OxyColor color1, OxyColor color2, double tt)
            {
                var alpha = (color1.A * (1 - tt)) + (color2.A * tt);
                var red = (color1.R * (1 - tt)) + (color2.R * tt);
                var green = (color1.G * (1 - tt)) + (color2.G * tt);
                var blue = (color1.B * (1 - tt)) + (color2.B * tt);
                return FromArgb((byte)alpha, (byte)red, (byte)green, (byte)blue);
            }

            /// <summary>
            /// Determines whether the specified colors are equal to each other.
            /// </summary>
            /// <param name="first">The first color.</param>
            /// <param name="second">The second color.</param>
            /// <returns><c>true</c> if the two colors are equal; otherwise, <c>false</c> .</returns>
            public static bool operator ==(OxyColor first, OxyColor second)
            {
                return first.Equals(second);
            }

            /// <summary>
            /// Determines whether the specified colors are not equal to each other.
            /// </summary>
            /// <param name="first">The first color.</param>
            /// <param name="second">The second color.</param>
            /// <returns><c>true</c> if the two colors are not equal; otherwise, <c>false</c> .</returns>
            public static bool operator !=(OxyColor first, OxyColor second)
            {
                return !first.Equals(second);
            }

            /// <summary>
            /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
            /// </summary>
            /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
            /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c> .</returns>
            public override bool Equals(object obj)
            {
                if (obj == null)
                {
                    return false;
                }

                if (obj.GetType() != typeof(OxyColor))
                {
                    return false;
                }

                return this.Equals((OxyColor)obj);
            }

            /// <summary>
            /// Determines whether the specified <see cref="OxyColor" /> is equal to this instance.
            /// </summary>
            /// <param name="other">The <see cref="OxyColor" /> to compare with this instance.</param>
            /// <returns><c>true</c> if the specified <see cref="OxyColor" /> is equal to this instance; otherwise, <c>false</c> .</returns>
            public bool Equals(OxyColor other)
            {
                return other.A == this.A && other.R == this.R && other.G == this.G && other.B == this.B;
            }

            /// <summary>
            /// Returns a hash code for this instance.
            /// </summary>
            /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
            public override int GetHashCode()
            {
                unchecked
                {
                    int result = this.A.GetHashCode();
                    result = (result * 397) ^ this.R.GetHashCode();
                    result = (result * 397) ^ this.G.GetHashCode();
                    result = (result * 397) ^ this.B.GetHashCode();
                    return result;
                }
            }

            /// <summary>
            /// Returns a <see cref="System.String" /> that represents this instance.
            /// </summary>
            /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
            public override string ToString()
            {
                return string.Format(
                    CultureInfo.InvariantCulture, "#{0:x2}{1:x2}{2:x2}{3:x2}", this.A, this.R, this.G, this.B);
            }

            /// <summary>
            /// Determines whether this color is invisible.
            /// </summary>
            /// <returns><c>True</c> if the alpha value is 0.</returns>
            public bool IsInvisible()
            {
                return this.A == 0;
            }

            /// <summary>
            /// Determines whether this color is visible.
            /// </summary>
            /// <returns><c>True</c> if the alpha value is greater than 0.</returns>
            public bool IsVisible()
            {
                return this.A > 0;
            }

            /// <summary>
            /// Determines whether this color is undefined.
            /// </summary>
            /// <returns><c>True</c> if the color equals <see cref="OxyColors.Undefined" />.</returns>
            public bool IsUndefined()
            {
                return this.Equals(OxyColors.Undefined);
            }

            /// <summary>
            /// Determines whether this color is automatic.
            /// </summary>
            /// <returns><c>True</c> if the color equals <see cref="OxyColors.Automatic" />.</returns>
            public bool IsAutomatic()
            {
                return this.Equals(OxyColors.Automatic);
            }

            /// <summary>
            /// Gets the actual color.
            /// </summary>
            /// <param name="defaultColor">The default color.</param>
            /// <returns>The default color if the current color equals OxyColors.Automatic, otherwise the color itself.</returns>
            public OxyColor GetActualColor(OxyColor defaultColor)
            {
                return this.IsAutomatic() ? defaultColor : this;
            }

            /// <summary>
            /// Returns C# code that generates this instance.
            /// </summary>
            /// <returns>The C# code.</returns>
            string ICodeGenerating.ToCode()
            {
                return this.ToCode();
            }
        }
    }
}