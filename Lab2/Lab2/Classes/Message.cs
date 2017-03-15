using Lab2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2.Classes
{
    class Message : IMessage
    {
        public bool IsSwapped { get; set; }

        public bool YesNo(string header, string message)
        {
            bool yesNo = false;
            DialogResult dialogRezult = MessageBox.Show($"{message}", $"{header}", MessageBoxButtons.YesNo);
            if (dialogRezult == DialogResult.OK)
            {
                yesNo = true;
                return yesNo;
            }
            else
            {
                yesNo = false;
                return yesNo;
            }
        }

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
