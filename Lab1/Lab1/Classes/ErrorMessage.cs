using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab1.Interfaces;

namespace Lab1.Classes
{
    class ErrorMessage : IErrorMessage
    {
        public void ShowMessage(string message)
        {
            throw new NotImplementedException();
        }

        public void ShowMessage(ErrorProvider errorProvider, Control control, string errorString = null)
        {
            {
                if (errorString == null)
                {
                    errorString = "";
                }
                errorProvider.SetError(control, errorString);
            }
        }
    }
}
