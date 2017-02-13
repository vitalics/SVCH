using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab1
{
    public partial class Part1 : Form
    {
        private double[] checkBoxItems = { 0.1, 0.2, 0.3 };
        public Part1()
        {
            InitializeComponent();
            FillCheckedListBox();
        }

        #region private methods

        private double ConvertValueToDouble(string value)
        {
            double rezult = 0;

            try
            {
                rezult = int.Parse(value);
            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message);
            }
            return rezult;
        }

        private void FillCheckedListBox()
        {
            checkedListBox1.CheckOnClick = true;
            var item = checkedListBox1.Items;


            for (int i = 0; i < checkBoxItems.Length; i++)
            {
                item.Add("dx = " + checkBoxItems[i]);
            }
        }

        private static double ExtractDecimalFromString(string str)
        {

            Regex digits = new Regex(@"^\D*?((-?(\d+(\.\d+)?))|(-?\.\d+)).*");
            Match mx = digits.Match(str);
            //Console.WriteLine("Input {0} - Digits {1} {2}", str, mx.Success, mx.Groups);

            return mx.Success ? Convert.ToDouble(mx.Groups[1].Value) : 0;
        }

        //private int GetChoosenElement(CheckedListBox checkedListBox)
        //{
        //    var choosenItem = checkedListBox.SelectedItem;
        //}
        #endregion

        #region events

        private void button1_Click(object sender, EventArgs e)
        {
            string bstr = textBox2.Text;
            string str = textBox1.Text;

            double x = ConvertValueToDouble(str);
            double b = ConvertValueToDouble(bstr);

            //string dxstr = new String(checkedListBox1.SelectedItem.ToString().Where(t => Char.IsDigit(t)).ToArray());
             

            double dx = ExtractDecimalFromString(checkedListBox1.SelectedItem.ToString());

            double y = 0;

            MessageBox.Show("Good!");

            for (int i = 0; i < 10; i++)
            {
                y = x * x + Math.Tan(5 * x + b / x); ;
                chart1.Series["Series1"].Points.AddXY
                                (x, y);
                x += dx;
            }

            chart1.Series["Series1"].ChartType =
                                SeriesChartType.Point;
            chart1.Series["Series1"].Color = Color.Red;
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count >= 1 && e.CurrentValue != CheckState.Checked)
            {
                e.NewValue = e.CurrentValue;
                MessageBox.Show("You can only check one item");
            }
        }

        #endregion

    }
}
