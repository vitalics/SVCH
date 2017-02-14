using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class AdderForm : Form
    {
        public AdderForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string textboxsrt = textBox1.Text;

            double addedValue = Part1.ExtractDoubleFromString(textboxsrt);
            var item = Part1.checkBoxItems;

            var addeditem = Part1.checkedListBox1.Items.Add("dx = " + addedValue);
            item.Add(addedValue);


            this.Close();
        }
    }
}
