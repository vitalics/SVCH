using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab1.Interfaces;

namespace Lab1.Classes
{
    class Message : IMessage
    {
        public bool IsSwapped { get; set; }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void SwapValues(Control swapControl1, Control swapControl2)
        {
            double value1 = Form1.ExtractDoubleFromString(swapControl1.Text);
            double value2 = Form1.ExtractDoubleFromString(swapControl2.Text);

            if (value1 > value2)
            {
                ShowMessage("first value is more, than second. I swapped him");
                var temp = swapControl1;
                swapControl1 = swapControl2;
                swapControl2 = temp;

                IsSwapped = true;
            }
        }
    }
}
