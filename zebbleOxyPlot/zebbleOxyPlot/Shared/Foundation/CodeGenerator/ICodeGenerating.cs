using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    partial class zebbleOxyPlot
    {
        /// <summary>
        /// Provides functionality to generate C# code of an object.
        /// </summary>
        public interface ICodeGenerating
        {
            /// <summary>
            /// Returns C# code that generates this instance.
            /// </summary>
            /// <returns>The C# code.</returns>
            string ToCode();
        }
    }
}