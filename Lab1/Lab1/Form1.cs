using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab1.Classes;
using System.Text.RegularExpressions;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab1
{
    public partial class Form1 : Form
    {
        #region private variables

        private Classes.IMessage message = new Classes.Message();
        private IErrorMessage errorMessage = new ErrorMessage();
        private Classes.IGraphic graphicChart = new Graphic();

        private bool isRunBefore = false;

        #endregion

        public Form1()
        {
            InitializeComponent();

            //prepare to start

            FillIncrementList();

            button1.Enabled = false;
            AddToList_button.Enabled = false;

            groupBox1.Contains(formula1);
            groupBox1.Contains(formula2);
            incrementList.CheckOnClick = true;
        }

        #region private methods

        private void FillIncrementList()
        {
            double beginValue = 0.1;
            var incrementItems = incrementList.Items;

            for (int i = 0; i < 10; i++)
            {
                incrementItems.Add("dx = " + beginValue);
                beginValue += i + 1;

            }

            incrementList.SelectedIndex = 2;
        }


        private static double ExtractDoubleFromString(string str)
        {

            Regex digits = new Regex(@"^\D*?((-?(\d+(\.\d+)?))|(-?\.\d+)).*");
            Match mx = digits.Match(str);

            return mx.Success ? Convert.ToDouble(mx.Groups[1].Value) : 0;
        }

        private double ConvertValueToDouble(string value)
        {
            double rezult = 0;

            try
            {
                rezult = double.Parse(value);
            }
            catch (FormatException fe)
            {
                message.ShowMessage(fe.Message);
            }
            return rezult;
        }
        #endregion

        #region Events

        #region Magic button

        private void button1_Click(object sender, EventArgs e)
        {
            double x0 = ExtractDoubleFromString(xValue.Text);
            double x1 = ExtractDoubleFromString(xLastValue.Text);
            double b = ExtractDoubleFromString(bValue.Text);
            double dx = ExtractDoubleFromString(incrementList.SelectedItem.ToString());
            double a = ExtractDoubleFromString(aValue.Text);

            if (isRunBefore)
            {
                foreach (var series in graphic.Series)
                {
                    series.Points.Clear();
                }
            }

            if (String.IsNullOrWhiteSpace(incrementList.SelectedItem.ToString()) || String.IsNullOrWhiteSpace(xValue.Text) || String.IsNullOrWhiteSpace(xLastValue.Text) || String.IsNullOrWhiteSpace(bValue.Text))
            {
                message.ShowMessage("Some value is not valid");
                return;
            }


            if (x0 == x1)
            {
                message.ShowMessage("first and last value is same");

                return;
            }

            colorDialog1.AllowFullOpen = false;
            colorDialog1.ShowHelp = true;


            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                graphicChart.CalculateAndBuild(x0, x1, b, dx, graphic, "Series1", colorDialog1.Color, SeriesChartType.Point, a);
                isRunBefore = true;
            }

            else
            {
                graphicChart.CalculateAndBuild(x0, x1, b, dx, graphic, "Series1", colorDialog1.Color, null, a);
                isRunBefore = true;
            }

        }
        #endregion

        private void formula1_MouseClick(object sender, MouseEventArgs e)
        {
            aValue.Enabled = false;

        }

        private void formula2_Click(object sender, EventArgs e)
        {
            aValue.Enabled = true;
        }


        private void incrementList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue != CheckState.Checked)
            {
                return;
            }

            // Get the items that are selected
            CheckedListBox.CheckedIndexCollection selectedItems = this.incrementList.CheckedIndices;

            // Check that we have at least 1 item selected
            if (selectedItems.Count > 0)
            {
                // Uncheck the other item
                this.incrementList.SetItemChecked(selectedItems[0], false);
            }
            if (selectedItems.Count == 0)
            {
                button1.Enabled = true;
            }
        }

        private void xValue_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                double x0 = double.Parse(xValue.Text);
                errorMessage.ShowMessage(xFirstValueProvider, xValue);
                button1.Enabled = true;

            }
            catch (FormatException)
            {
                errorMessage.ShowMessage(xFirstValueProvider, xValue, "Not a value.");
                button1.Enabled = false;
            }
            catch (OverflowException)
            {
                errorMessage.ShowMessage(xLastProvider, xLastValue, "So big value.");
                button1.Enabled = false;
            }
        }

        private void xLastValue_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                double x1 = double.Parse(xLastValue.Text);
                errorMessage.ShowMessage(xLastProvider, xLastValue);
                button1.Enabled = true;
            }
            catch (FormatException)
            {
                errorMessage.ShowMessage(xLastProvider, xLastValue, "Not a value.");
                button1.Enabled = false;
            }
            catch (OverflowException)
            {
                errorMessage.ShowMessage(xLastProvider, xLastValue, "So big value.");
                button1.Enabled = false;
            }

        }

        private void bValue_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                double b = double.Parse(bValue.Text);

                if (b >= double.MaxValue || b <= double.MinValue)
                {
                    errorMessage.ShowMessage(bValueProvider, bValue, "So big value");
                }

                errorMessage.ShowMessage(bValueProvider, bValue);
                button1.Enabled = true;

            }
            catch (FormatException)
            {
                errorMessage.ShowMessage(bValueProvider, bValue, "Not a value.");
                button1.Enabled = false;
            }
            catch (OverflowException)
            {
                errorMessage.ShowMessage(xLastProvider, xLastValue, "So big value.");
                button1.Enabled = false;
            }
        }

        private void aValue_Validating(object sender, CancelEventArgs e)
        {
            if (aValue.Enabled == false)
            {
                errorMessage.ShowMessage(aValueProvider, aValue);
            }
            try
            {
                double a = double.Parse(aValue.Text);
                errorMessage.ShowMessage(aValueProvider, aValue);
                button1.Enabled = true;

            }
            catch (FormatException)
            {
                errorMessage.ShowMessage(aValueProvider, aValue, "Not a value");
                button1.Enabled = false;
            }
            catch (OverflowException)
            {
                errorMessage.ShowMessage(xLastProvider, xLastValue, "So big value.");
                button1.Enabled = false;
            }
        }


        private void aValue_EnabledChanged(object sender, EventArgs e)
        {
            errorMessage.ShowMessage(aValueProvider, aValue);
        }

        private void dxValue_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                double dx = double.Parse(dxValue.Text);
                errorMessage.ShowMessage(dxErrorProvider, dxValue);
                AddToList_button.Enabled = true;
            }
            catch (FormatException)
            {
                errorMessage.ShowMessage(dxErrorProvider, dxValue, "Not a value");
                AddToList_button.Enabled = false;
            }

            catch (OverflowException)
            {
                errorMessage.ShowMessage(dxErrorProvider, dxValue, "So big value");
                AddToList_button.Enabled = false;
            }
        }

        private void AddToList_button_Click(object sender, EventArgs e)
        {
            double dx = double.Parse(dxValue.Text);

            int index = incrementList.FindString("dx = " + dx.ToString(), 0);

            if (index != -1)
            {
                incrementList.SetSelected(index, true);
                message.ShowMessage("The value " + dx.ToString() + " is has already added in list");

                dxValue.Text = "";
                return;
            }
            else
            {
                incrementList.Items.Add("dx = " + dx);
            }
        }

        #endregion

    }
}
