using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1.Classes
{
    interface IErrorMessage : IMessage
    {
        void ShowMessage(ErrorProvider errorProvider, Control control, string errorString = null);
    }
}
