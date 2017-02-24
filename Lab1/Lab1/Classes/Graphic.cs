using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;

namespace Lab1.Classes
{
    class Graphic : IGraphic
    {
        private IMessage message = new Message();
        public void CalculateAndBuild(double x0, double x1, double b, double dx, Chart chart, string seriesName, Color? color, SeriesChartType? chartType = SeriesChartType.Point, double? a = null)
        {
            int counter = 0;
            //chart.Series.Clear();
            if (chartType == null)
            {
                chartType = SeriesChartType.Point;
            }
            if (color == null)
            {
                color = Color.Red;
            }
            double y = 0;

            // swap
            if (x0 > x1)
            {
                var temp = x0;
                x0 = x1;
                x1 = temp;
            }

            while (x0 < x1)
            {
                if (a.Value == 0)
                {
                    y = x0 * x0 + Math.Tan(5 * x0 + b / x0);
                }
                else
                {
                    y = 0.1 * a.Value * Math.Pow(x0, 3) * Math.Tan(a.Value - b * x0);
                }
                if (counter >= 500)
                {
                    return;
                }

                chart.Series[$"{seriesName}"].Points.AddXY(x0, y);

                x0 += dx;


                chart.Series[$"{seriesName}"].ChartType = chartType.Value;
                chart.Series[$"{seriesName}"].Color = color.Value;

                counter++;
            }
        }
    }
}
