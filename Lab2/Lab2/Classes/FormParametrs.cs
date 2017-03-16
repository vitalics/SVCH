using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2.Classes
{
    [Serializable]
    public class FormParametrs
    {
        public int width;

        public int heigth;

        public bool isFirstFormula;

        public double xFirstValue;
        public double xLastValue;
        public double b;
        public double a;
        public double dx;

        public FormParametrs DefaultParametrs()
        {
            width = 650;
            heigth = 450;
            isFirstFormula = true;
            xFirstValue = 1243;
            xLastValue = 123;
            b = 12;
            a = 1;
            dx = 3.1;

            return this;
        }
    }
}