using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    partial class zebbleOxyPlot
    {
        /// <summary>
        /// Defines the image format.
        /// </summary>
        public enum ImageFormat
        {
            /// <summary>
            /// The image is a PNG image.
            /// </summary>
            Png,

            /// <summary>
            /// The image is a bitmap image.
            /// </summary>
            Bmp,

            /// <summary>
            /// The image is a JPEG image.
            /// </summary>
            Jpeg,

            /// <summary>
            /// The image format is unknown.
            /// </summary>
            Unknown
        }
    }
}