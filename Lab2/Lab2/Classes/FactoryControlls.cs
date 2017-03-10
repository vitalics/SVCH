using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2.Classes
{
    class FactoryControlls
    {
        static Control _controll;

        public FactoryControlls(Control control)
        {
            _controll = control;
        }
        public FactoryControlls()
        {

        }

        public static Control CreateControl(Control control)
        {
            control = new Control();
            return control;
        }
    }
}
