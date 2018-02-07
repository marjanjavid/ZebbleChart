using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Zebble
{
    public class ChartLayout:FrameLayout
    {
        ScrollView ScrollView;

        public ChartLayout(Context context) : base(context) { }
        public override bool DispatchTouchEvent(MotionEvent ev)
        {
            FindScrollView();
            var nativeScrollView = ScrollView?.Native as Android.Widget.ScrollView;

            switch (ev.Action)
            {
                case MotionEventActions.Up:
                case MotionEventActions.Down:
                    if (nativeScrollView == null) break;
                    nativeScrollView.RequestDisallowInterceptTouchEvent(disallowIntercept: true);
                    ScrollView.EnableScrolling = false;
                    break;
                default:
                    break;
            }
            return base.DispatchTouchEvent(ev);
        }
        internal void FindScrollView()
        {
            if (ScrollView != null) return;

            foreach (var child in UIRuntime.PageContainer.AllChildren)
            {
                if (child is Page currentPage)
                {
                    foreach (var pageChild in currentPage.AllChildren)
                    {
                        if (pageChild is Canvas scrollWrapper && scrollWrapper.Id != null && scrollWrapper.Id == "BodyScrollerWrapper")
                        {
                            ScrollView = scrollWrapper.AllChildren.FirstOrDefault() as Zebble.ScrollView;
                            break;
                        }
                    }

                    if (ScrollView != null) break;
                }
            }
        }
    }
}