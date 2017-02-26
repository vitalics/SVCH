using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab1.Interfaces
{
    interface IGraphic
    {
        void CalculateAndBuild(double x0, double x1, double b, double dx, Chart chart, string seriesName, Color? color, SeriesChartType? chartType = SeriesChartType.Point, double? a = null);
    }
}
