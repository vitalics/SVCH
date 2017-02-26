using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab1.Interfaces;

namespace Lab1.Classes
{
    class Check : ICheck
    {
        IErrorMessage errorMessage = new ErrorMessage();
        IMessage message = new Message();

        public bool IsChecked { get; set; }

        public bool IsNullOrEmptyContol(Control control)
        {
            if (string.IsNullOrWhiteSpace(control.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsNullOrEmptyValue(double value)
        {
            if (String.IsNullOrWhiteSpace(value.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsSameValues(double value1, double value2)
        {
            if (value1 == value2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SwapTextInControls(Control swapControl1, Control swapControl2)
        {
            double value1 = 0;
            double value2 = 0;
            try
            {
                value1 = double.Parse(swapControl1.Text);
                value2 = double.Parse(swapControl2.Text);
            }
            catch (FormatException e)
            {
                errorMessage.ShowMessage(e.Message);
            }

            if (value1 > value2)
            {
                message.ShowMessage("first value is more, than second. I swapped him");
                var temp = swapControl1.Text;
                swapControl1.Text = swapControl2.Text;
                swapControl2.Text = temp;
            }

        }

        bool ICheck.IsNullOrEmptyString(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //public void SwapValues(Control swapControl1, Control swapControl2)
        //{
        //    double value1 = Form1.ExtractDoubleFromString(swapControl1.Text);
        //    double value2 = Form1.ExtractDoubleFromString(swapControl2.Text);

        //    if (value1 > value2)
        //    {
        //        message.ShowMessage("first value is more, than second. I swapped him");
        //        var temp = swapControl1;
        //        swapControl1 = swapControl2;
        //        swapControl2 = temp;
        //    }
        //}
    }
}
