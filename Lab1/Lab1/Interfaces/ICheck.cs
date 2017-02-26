using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1.Interfaces
{
    interface ICheck
    {
        bool IsChecked { get; set; }

        void SwapTextInControls(Control swapControl1, Control swapControl2);

        bool IsSameValues(double value1, double value2);

        bool IsNullOrEmptyContol(Control control);

        bool IsNullOrEmptyValue(double value);

        bool IsNullOrEmptyString(string value);
    }
}
