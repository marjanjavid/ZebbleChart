using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    partial class zebbleOxyPlot
    {
        /// <summary>
        /// Provides polygon clipping by the Sutherland-Hodgman algorithm.
        /// </summary>
        public static class SutherlandHodgmanClipping
        {
            /// <summary>
            /// The rectangle edge.
            /// </summary>
            private enum RectangleEdge
            {
                /// <summary>
                /// The left.
                /// </summary>
                Left,

                /// <summary>
                /// The right.
                /// </summary>
                Right,

                /// <summary>
                /// The top.
                /// </summary>
                Top,

                /// <summary>
                /// The bottom.
                /// </summary>
                Bottom
            }

            /// <summary>
            /// The Sutherland-Hodgman polygon clipping algorithm.
            /// </summary>
            /// <param name="bounds">The bounds.</param>
            /// <param name="vv">The polygon points.</param>
            /// <returns>The clipped points.</returns>
            /// <remarks>See <a href="http://ezekiel.vancouver.wsu.edu/~cs442/lectures/clip/clip/index.html">link</a>.</remarks>
            public static List<ScreenPoint> ClipPolygon(OxyRect bounds, IList<ScreenPoint> vv)
            {
                var p1 = ClipOneAxis(bounds, RectangleEdge.Left, vv);
                var p2 = ClipOneAxis(bounds, RectangleEdge.Right, p1);
                var p3 = ClipOneAxis(bounds, RectangleEdge.Top, p2);
                return ClipOneAxis(bounds, RectangleEdge.Bottom, p3);
            }

            /// <summary>
            /// Clips to one axis.
            /// </summary>
            /// <param name="bounds">The bounds.</param>
            /// <param name="edge">The edge.</param>
            /// <param name="vv">The points of the polygon.</param>
            /// <returns>The clipped points.</returns>
            private static List<ScreenPoint> ClipOneAxis(OxyRect bounds, RectangleEdge edge, IList<ScreenPoint> vv)
            {
                if (vv.Count == 0)
                {
                    return new List<ScreenPoint>();
                }

                var polygon = new List<ScreenPoint>(vv.Count);

                var ss = vv[vv.Count - 1];

                for (int i = 0; i < vv.Count; ++i)
                {
                    var pp = vv[i];
                    bool pin = IsInside(bounds, edge, pp);
                    bool sin = IsInside(bounds, edge, ss);

                    if (sin && pin)
                    {
                        // case 1: inside -> inside
                        polygon.Add(pp);
                    }
                    else if (sin)
                    {
                        // case 2: inside -> outside
                        polygon.Add(LineIntercept(bounds, edge, ss, pp));
                    }
                    else if (!pin)
                    {
                        // case 3: outside -> outside
                        // emit nothing
                    }
                    else
                    {
                        // case 4: outside -> inside
                        polygon.Add(LineIntercept(bounds, edge, ss, pp));
                        polygon.Add(pp);
                    }

                    ss = pp;
                }

                return polygon;
            }

            /// <summary>
            /// Determines whether the specified point is inside the edge/bounds.
            /// </summary>
            /// <param name="bounds">The bounds.</param>
            /// <param name="edge">The edge to test.</param>
            /// <param name="pp">The point.</param>
            /// <returns><c>true</c> if the specified point is inside; otherwise, <c>false</c>.</returns>
            private static bool IsInside(OxyRect bounds, RectangleEdge edge, ScreenPoint pp)
            {
                switch (edge)
                {
                    case RectangleEdge.Left:
                        return !(pp.X < bounds.Left);

                    case RectangleEdge.Right:
                        return !(pp.X >= bounds.Right);

                    case RectangleEdge.Top:
                        return !(pp.Y < bounds.Top);

                    case RectangleEdge.Bottom:
                        return !(pp.Y >= bounds.Bottom);

                    default:
                        throw new ArgumentException("edge");
                }
            }

            /// <summary>
            /// Fines the edge interception.
            /// </summary>
            /// <param name="bounds">The bounds.</param>
            /// <param name="edge">The edge.</param>
            /// <param name="aa">The first point.</param>
            /// <param name="bb">The second point.</param>
            /// <returns>The interception.</returns>
            private static ScreenPoint LineIntercept(OxyRect bounds, RectangleEdge edge, ScreenPoint aa, ScreenPoint bb)
            {
                if (aa.x.Equals(bb.x) && aa.y.Equals(bb.y))
                {
                    return aa;
                }

                switch (edge)
                {
                    case RectangleEdge.Bottom:
                        if (bb.Y.Equals(aa.Y))
                        {
                            throw new ArgumentException("no intercept found");
                        }

                        return new ScreenPoint(aa.X + (((bb.X - aa.X) * (bounds.Bottom - aa.Y)) / (bb.Y - aa.Y)), bounds.Bottom);

                    case RectangleEdge.Left:
                        if (bb.X.Equals(aa.X))
                        {
                            throw new ArgumentException("no intercept found");
                        }

                        return new ScreenPoint(bounds.Left, aa.Y + (((bb.Y - aa.Y) * (bounds.Left - aa.X)) / (bb.X - aa.X)));

                    case RectangleEdge.Right:
                        if (bb.X.Equals(aa.X))
                        {
                            throw new ArgumentException("no intercept found");
                        }

                        return new ScreenPoint(bounds.Right, aa.Y + (((bb.Y - aa.Y) * (bounds.Right - aa.X)) / (bb.X - aa.X)));

                    case RectangleEdge.Top:
                        if (bb.Y.Equals(aa.Y))
                        {
                            throw new ArgumentException("no intercept found");
                        }

                        return new ScreenPoint(aa.X + (((bb.X - aa.X) * (bounds.Top - aa.Y)) / (bb.Y - aa.Y)), bounds.Top);
                    default:
                        break;
                }

                throw new ArgumentException("no intercept found");
            }
        }
    }
}