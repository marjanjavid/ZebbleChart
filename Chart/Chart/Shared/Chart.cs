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
       
        public PlotModel plotModel { get; set; }
        public OxyPlot.PlotModel oxyplotModel { get; internal set; }
        //bool showXAxis = true, showYAxix = true, isZoomable = true, isMovable = true;
        //IPlotType chart;
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
            foreach (var chart in plotModel.Series)
            {
                 if (chart is TwoColorArea)//it should be placed before Area if clause
                {
                    var twoColorAreaSeries = new TwoColorAreaSeries
                    {
                        Color = ChartColor.CastToOxyColor(((TwoColorArea)chart).Color),
                        Color2 = ChartColor.CastToOxyColor(((TwoColorArea)chart).Color2),
                        Limit = ((TwoColorArea)chart).Limit
                    };
                    foreach (var item in ((TwoColorArea)chart).Data)
                    {
                        twoColorAreaSeries.Points.Add(item);
                    }
                    this.oxyplotModel.Series.Add(twoColorAreaSeries);
                    
                }
                else if (chart is Area)
                {
                    var areaSeries = new AreaSeries();
                    foreach (var point in ((Area)chart).Data)
                    {
                        areaSeries.Points.Add(point);
                    }
                    this.oxyplotModel.Series.Add(areaSeries);
                }
                else if (chart is TwoColorLine)//it should be placed before line if clause
                {
                    var twoColorLineSeries = new TwoColorLineSeries
                    {
                        Color = ChartColor.CastToOxyColor(((TwoColorLine)chart).Color),
                        Color2 = ChartColor.CastToOxyColor(((TwoColorLine)chart).Color2),
                        Limit = ((TwoColorLine)chart).Limit
                    };
                    foreach (var item in ((TwoColorLine)chart).Data)
                    {
                        twoColorLineSeries.Points.Add(item);
                    }
                    this.oxyplotModel.Series.Add(twoColorLineSeries);
                    
                }
                else if (chart is Line)
                {
                    var lineSeries = new LineSeries
                    {
                        MarkerType = MarkerType.Circle,
                        MarkerSize = 4,
                        MarkerStroke = OxyColors.White
                    };

                    foreach (var point in ((Line)chart).Data)
                    {
                        lineSeries.Points.Add(point);
                    }
                    this.oxyplotModel.Series.Add(lineSeries);
                    
                }
                else if (chart is Pie)
                {
                    var pieSeries = new PieSeries();
                    foreach (var slice in ((Pie)chart).Data)
                    {
                        pieSeries.Slices.Add(slice);
                    }
                    this.oxyplotModel.Series.Add(pieSeries);
                }
                else if (chart is Bar)
                {
                    var barSeries = new BarSeries();
                    foreach (var item in ((Bar)chart).Data)
                    {
                        barSeries.Items.Add(item);
                    }
                    this.oxyplotModel.Series.Add(barSeries);
                    
                }
                else if(chart is ErrorColumn)
                {
                    var errorColumn = new ErrorColumnSeries();
                    foreach (ErrorColumnItem item in ((ErrorColumn)chart).Data)
                    {
                        errorColumn.Items.Add((OxyPlot.Series.ErrorColumnItem)item);
                    }
                    this.oxyplotModel.Series.Add(errorColumn);
                    
                }
                else if (chart is Column)
                {
                    var barSeries = new ColumnSeries();
                    foreach (var item in ((Column)chart).Data)
                    {
                        barSeries.Items.Add(item);
                    }
                    this.oxyplotModel.Series.Add(barSeries);
                    
                }
                else if (chart is Box)
                {
                    var boxSeries = new BoxPlotSeries();
                    foreach (var item in ((Box)chart).Data)
                    {
                        boxSeries.Items.Add(item);
                    }
                    this.oxyplotModel.Series.Add(boxSeries);
                }
                else if (chart is Contour)
                {
                    var contourSeries = new ContourSeries
                    {
                        Data = ((Contour)chart).Data,
                        ColumnCoordinates = ((Contour)chart).ColumnCoordinates,
                        RowCoordinates = ((Contour)chart).RowCoordinates
                    };
                    this.oxyplotModel.Series.Add(contourSeries);

                }
                else if (chart is RectangleBar)
                {
                    var rectangleBarSeries = new RectangleBarSeries
                    {
                        Title = ((RectangleBar)chart).Title
                    };
                    foreach (var item in ((RectangleBar)chart).Data)
                    {
                        rectangleBarSeries.Items.Add(item);
                    }
                    this.oxyplotModel.Series.Add(rectangleBarSeries);
                }
                 else if(chart is CandleStick)
                {
                    var candleStickSeries = new CandleStickSeries();
                    foreach(var item in ((CandleStick)chart).Data)
                    {
                        candleStickSeries.Items.Add(item);
                    }
                    this.oxyplotModel.Series.Add(candleStickSeries);
                }
                 else if(chart is HeatMap)
                {
                    var heatMapSeries = new HeatMapSeries() {
                        Data = ((HeatMap)chart).Data,
                        X0 = ((HeatMap)chart).X0,
                        X1 = ((HeatMap)chart).X1,
                        Y0 = ((HeatMap)chart).Y0,
                        Y1= ((HeatMap)chart).Y1,
                        Interpolate = ((HeatMap)chart).Interpolate,
                        RenderMethod = ((HeatMap)chart).RenderMethod
                    };
                    this.oxyplotModel.Series.Add(heatMapSeries);
                }
            }
            foreach(var axis in plotModel.Axes)
            {
                this.oxyplotModel.Axes.Add(axis);

            }
        }
        public override void Dispose()
        {
            base.Dispose();
        }

    }
}