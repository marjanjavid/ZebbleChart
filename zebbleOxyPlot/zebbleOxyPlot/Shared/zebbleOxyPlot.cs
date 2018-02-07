namespace Zebble
{
    using OxyPlot;
    using OxyPlot.Annotations;
    using OxyPlot.Axes;
    using OxyPlot.Series;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using System.Threading.Tasks;
    using Zebble;

    public partial class zebbleOxyPlot : View, IRenderedBy<zebbleOxyPlotRenderer>
    {
        //#region PlotModel
        //public double LegendPadding { get; set; }
        //public OxyColor LegendTitleColor { get; set; }
        //public string LegendTitle { get; set; }
        //public LegendSymbolPlacement LegendSymbolPlacement { get; set; }
        //public double LegendSymbolMargin { get; set; }
        //public double LegendSymbolLength { get; set; }
        //public LegendPosition LegendPosition { get; set; }
        //public LegendPlacement LegendPlacement { get; set; }
        public string Title { get; set; }
        //public LegendOrientation LegendOrientation { get; set; }
        //public double LegendMaxHeight { get; set; }
        //public double LegendMaxWidth { get; set; }
        //public double LegendMargin { get; set; }
        //public double LegendLineSpacing { get; set; }
        //public double LegendItemSpacing { get; set; }
        //public LegendItemOrder LegendItemOrder { get; set; }
        //public string LegendTitleFont { get; set; }
        //public double LegendTitleFontSize { get; set; }
        //public double LegendTitleFontWeight { get; set; }
        //public OxyThickness Padding { get; set; }
        //public double SubtitleFontSize { get; set; }
        //public string SubtitleFont { get; set; }
        //public string Subtitle { get; set; }
        //public Func<IRenderContext, IRenderContext> RenderingDecorator { get; set; }
        ////public ElementCollection<Series.Series> Series { get; }
        //public PlotType PlotType { get; set; }
        //public OxyThickness PlotMargins { get; set; }
        //public OxyThickness PlotAreaBorderThickness { get; set; }
        //public OxyColor PlotAreaBorderColor { get; set; }
        //public OxyColor PlotAreaBackground { get; set; }
        //public double AxisTierDistance { get; set; }
        //public OxyRect PlotArea { get; }
        //public OxyRect PlotAndAxisArea { get; }
        //public double Height { get; }
        //public double Width { get; }
        //public HorizontalAlignment LegendItemAlignment { get; set; }
        //public double LegendFontWeight { get; set; }
        //public OxyColor LegendTextColor { get; set; }
        //public double LegendFontSize { get; set; }
        //public IColorAxis DefaultColorAxis { get; }
        //public Axis DefaultYAxis { get; }
        //public Axis DefaultXAxis { get; }
        //public MagnitudeAxis DefaultMagnitudeAxis { get; }
        //public AngleAxis DefaultAngleAxis { get; }
        //public double TitlePadding { get; set; }
        //public double TitleFontWeight { get; set; }
        //public double TitleFontSize { get; set; }
        //public string TitleFont { get; set; }
        //public OxyRect TitleArea { get; }
        //public TitleHorizontalAlignment TitleHorizontalAlignment { get; set; }
        //public OxyColor SubtitleColor { get; set; }
        //public OxyColor TitleColor { get; set; }
        //public double SubtitleFontWeight { get; set; }
        //public string DefaultFont { get; set; }
        //public string TitleToolTip { get; set; }
        //public CultureInfo ActualCulture { get; }
        //public string LegendFont { get; set; }
        //public double LegendColumnSpacing { get; set; }
        //public double LegendBorderThickness { get; set; }
        //public OxyColor LegendBorder { get; set; }
        //public OxyColor LegendBackground { get; set; }
        //public double DefaultFontSize { get; set; }
        //public bool IsLegendVisible { get; set; }
        //public OxyRect LegendArea { get; }
        //public CultureInfo Culture { get; set; }
        //public OxyColor Background { get; set; }
        //public ElementCollection<Axis> Axes { get; }
        //public ElementCollection<Annotation> Annotations { get; }
        //public IPlotView PlotView { get; }
        //public OxyThickness ActualPlotMargins { get; }
        //public IList<OxyColor> DefaultColors { get; set; }
        //public OxyColor TextColor { get; set; }
        //protected string ActualTitleFont { get; }
        //protected string ActualSubtitleFont { get; }
//#endregion
        //   // ---------------------- TODO: PROPERTIES -------------------------        
        //// Use the following pattern for each property.
        //MyPropertyType myProperty; // Used to hold the value.
        //internal readonly AsyncEvent MyPropertyChanged = new AsyncEvent(); // Used to cascade changes to the native object.

        //public MyPropertyType MyProperty // The public api for your component
        //{
        //    get => myProperty;
        //	set { if (myProperty != value) { myProperty = value; MyPropertyChanged.Raise(); } }
        //}


        //      // ---------------------- TODO: METHODS -------------------------        
        //      // For each method that you need, provide an internal delegate, and a public method.
        //      // Then provide the delegate's implementation in each platform's Renderer class.
        //      internal Action MyMethod1Implementation;
        //      public void MyMethod1() => MyMethod1Implementation?.Invoke();

        //      internal Func<int, string> MyMethod2Implementation;
        //      public string MyMethod2(int param1) => MyMethod2Implementation?.Invoke(param1);



        //      // ---------------------- TODO: EVENTS -------------------------        
        //      // For each event that you need, provide an AsyncEvent object.
        //      public readonly AsyncEvent MyEvent1 = new AsyncEvent();
        //      public readonly AsyncEvent<TEventArg> MyEvent2 = new AsyncEvent<TEventArg>();

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}