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
        public static List<double> checkBoxItems = new List<double>();
        public Part1()
        {
            InitializeComponent();
            FillCheckedListBox();
        }

        #region public methods

        public static double ExtractDoubleFromString(string str)
        {

            Regex digits = new Regex(@"^\D*?((-?(\d+(\.\d+)?))|(-?\.\d+)).*");
            Match mx = digits.Match(str);

            return mx.Success ? Convert.ToDouble(mx.Groups[1].Value) : 0;
        }

        public static double ConvertValueToDouble(string value)
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

        #endregion

        #region private methods



        private void FillCheckedListBox()
        {
            checkedListBox1.CheckOnClick = true;
            var item = checkedListBox1.Items;


            for (int i = 0; i < checkBoxItems.ToArray().Length; i++)
            {
                item.Add("dx = " + checkBoxItems[i]);
            }
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

            double dx = ExtractDoubleFromString(checkedListBox1.SelectedItem.ToString());

            double y = 0;

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

        private void button2_Click(object sender, EventArgs e)
        {
            AdderForm adderForm = new AdderForm();
            adderForm.Show();
        }
    }
}
