using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Classes
{
    [Serializable]
    public class FormSize
    {
        private int _width;
        private int _heigth;

        public int width;
        public int heigth;

        public FormSize()
        {

        }
        public FormSize(int width, int heigth)
        {
            _width = width;
            _heigth = heigth;
        }
    }
}
