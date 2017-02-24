using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab1.Classes;

namespace Lab1.Classes
{
    class Message : IMessage
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
