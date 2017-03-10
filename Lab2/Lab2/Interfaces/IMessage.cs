using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2.Interfaces
{
    interface IMessage
    {
        void ShowMessage(string message);
        bool YesNo(string header, string message);
    }
}
