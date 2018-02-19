namespace Zebble
{
    using OxyPlot;
    using OxyPlot.Axes;
    using OxyPlot.Series;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Zebble;

    public partial class Chart : View, IRenderedBy<ChartRenderer>
    {
        public PlotModel plotModel = new PlotModel();
        public OxyPlot.PlotModel oxyplotModel { get; internal set; }
        //bool showXAxis = true, showYAxix = true, isZoomable = true, isMovable = true;
        IPlotType chart;
        //public bool ShowXAxis
        //{
        //    get => showXAxis;
        //    set
        //    {
        //        if (showXAxis == value) return;
        //        showXAxis = value;
        //    }
        //}
        //public bool ShowYAxix
        //{
        //    get => showYAxix;
        //    set
        //    {
        //        if (showYAxix == value) return;
        //        showYAxix = value;
        //    }
        //}
        //public bool IsZoomable
        //{
        //    get => isZoomable;
        //    set
        //    {
        //        if (isZoomable == value) return;
        //        isZoomable = value;
        //    }
        //}
        //public bool IsMovable
        //{
        //    get => isMovable;
        //    set
        //    {
        //        if (isMovable == value) return;
        //        isMovable = value;
        //    }
        //}

        public async Task Add(PlotModel plotModel)
        {
            this.oxyplotModel = new OxyPlot.PlotModel();
            this.oxyplotModel.Title = plotModel.Title;
            if (plotModel.Chart is Area)
            {
                var areaSeries = new AreaSeries();
                foreach (var point in ((Area)plotModel.Chart).Data)
                {
                    areaSeries.Points.Add(point);
                }
                this.oxyplotModel.Series.Add(areaSeries);
            }
            else if (plotModel.Chart is Line)
            {
                var lineSeries = new LineSeries
                {
                    MarkerType = MarkerType.Circle,
                    MarkerSize = 4,
                    MarkerStroke = OxyColors.White
                };

                foreach (var point in ((Line)plotModel.Chart).Data)
                {
                    lineSeries.Points.Add(point);
                }
                this.oxyplotModel.Series.Add(lineSeries);
                this.oxyplotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
                this.oxyplotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 10, Minimum = 0 });
            }
            else if (plotModel.Chart is Pie)
            {
                var pieSeries = new PieSeries();
                foreach (var slice in ((Pie)plotModel.Chart).Data)
                {
                    pieSeries.Slices.Add(slice);
                }
                this.oxyplotModel.Series.Add(pieSeries);
            }
            //switch (chartType)
            //{
            //   
            //    case PlotType.Bar:

            //        break;
            //    case PlotType.BoxPlot:
            //        break;
            //    case PlotType.CandleStick:
            //        break;
            //    case PlotType.Column:
            //        var columnSeries = new ColumnSeries();
            //        columnSeries.Items.Add(new Zebble.ColumnItem(100));
            //        this.plotModel.Series.Add(columnSeries);
            //        break;
            //    case PlotType.Contour:
            //        break;
            //    case PlotType.ErrorColumn:
            //        break;
            //    case PlotType.Function:
            //        break;
            //    case PlotType.HeatMap:
            //        break;
            //    case PlotType.HighLow:
            //        break;
            //    case PlotType.IntervalBar:
            //        break;

            //    case PlotType.Pie:
            //        var ps = new PieSeries
            //        {
            //            StrokeThickness = 2.0,
            //            InsideLabelPosition = 0.8,
            //            AngleSpan = 360,
            //            StartAngle = 0
            //        };
            //        ps.Slices.Add(new PieSlice("Africa", 1030) { IsExploded = true });
            //        ps.Slices.Add(new PieSlice("Americas", 929) { IsExploded = true });
            //        ps.Slices.Add(new PieSlice("Asia", 4157));
            //        ps.Slices.Add(new PieSlice("Europe", 739) { IsExploded = true });
            //        ps.Slices.Add(new PieSlice("Oceania", 35) { IsExploded = true });

            //        this.plotModel.Series.Add(ps);
            //        break;
            //    case PlotType.RectangleBar:
            //        break;
            //    case PlotType.Scatter:
            //        break;
            //    case PlotType.StairStep:
            //        break;
            //    case PlotType.Stem:
            //        break;
            //    case PlotType.TornadoBar:
            //        break;
            //    case PlotType.TwoColorArea:
            //        break;
            //    case PlotType.TwoColorLine:
            //        break;
            //    default:
            //        break;
            //}

        }
        public override void Dispose()
        {
            base.Dispose();
        }
        //public enum PlotType
        //{
        //    Area,
        //    Bar,
        //    BoxPlot,
        //    CandleStick,
        //    Column,
        //    Contour,
        //    ErrorColumn,
        //    Function,
        //    HeatMap,
        //    HighLow,
        //    IntervalBar,
        //    Line,
        //    Pie,
        //    RectangleBar,
        //    Scatter,
        //    StairStep,
        //    Stem,
        //    TornadoBar,
        //    TwoColorArea,
        //    TwoColorLine
        //}
    }
}