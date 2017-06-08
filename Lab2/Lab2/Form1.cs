using Lab2.Classes;
using Lab2.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Serialization;

namespace Lab2
{
    public partial class Form1 : Form
    {
        #region public varialbes

        public string fileName = Environment.CurrentDirectory + "\\applicationSettings.xml";

        public XmlSerializer xmlser;

        #endregion

        #region private variables

        double x1 = 0;
        double x2 = 0;
        double b = 0;
        double a = 0;
        double dx = 0;
        double selectedItem = 0;


        bool isFirstChecked = true;
        bool isDeserialize = false;

        private int currentStep = 1;
        private int maxSteps = 5;

        private int textBoxMaxNumbers = 10;

        IMessage message = new Classes.Message();

        IErrorMessage errorMessage = new ErrorMessage();

        FileStream fileStream;
        StreamReader reader;
        FormParametrs formParametrs = new FormParametrs();

        LinkLabel welcomeLinkLabel = new LinkLabel();

        Label header = new Label();

        RadioButton formula1 = new RadioButton();
        RadioButton formula2 = new RadioButton();

        Label xFirstValueLabel = new Label();
        Label xLastValueLabel = new Label();
        Label bValueLabel = new Label();
        Label aValueLabel = new Label();

        TextBox xFirstValue = new TextBox();
        TextBox xLastValue = new TextBox();
        TextBox bValue = new TextBox();
        TextBox aValue = new TextBox();

        CheckedListBox incrementList = new CheckedListBox();
        TextBox incrementAdder = new TextBox();
        Button AdderButton = new Button();

        //Chart chart1 = new Chart();

        Graphic graphicChart = new Graphic();

        #endregion

        public Form1()
        {
            InitializeComponent();

            MinimumSize = new Size(660, 450);

            DisposeControll(CreateIncrementList());

            Master(currentStep);
        }

        #region public methods
        public static double ExtractDoubleFromString(string str)
        {

            Regex digits = new Regex(@"^\D*?((-?(\d+(\.\d+)?))|(-?\.\d+)).*");
            Match mx = digits.Match(str);

            return mx.Success ? Convert.ToDouble(mx.Groups[1].Value) : 0;
        }
        #endregion

        #region private methods

        private void ClearPointChart()
        {
            foreach (var item in chart1.Series)
            {
                item.Points.Clear();
            }
        }

        private void Serialize()
        {
            formParametrs.heigth = this.Height;
            formParametrs.width = this.Width;

            if (isDeserialize)
            {
                x1 = formParametrs.xFirstValue;
                x2 = formParametrs.xLastValue;
                b = formParametrs.b;
                a = formParametrs.a;
                dx = formParametrs.dx;
            }
            else
            {
                x1 = ExtractDoubleFromString(xFirstValue.Text);
                x2 = ExtractDoubleFromString(xLastValue.Text);
                b = ExtractDoubleFromString(bValue.Text);
                a = ExtractDoubleFromString(aValue.Text);
                dx = ExtractDoubleFromString(incrementList.SelectedItem.ToString());
            }

            formParametrs.isFirstFormula = isFirstChecked;
            formParametrs.xFirstValue = x1;
            formParametrs.xLastValue = x2;
            formParametrs.b = b;
            formParametrs.a = a;
            formParametrs.dx = dx;


            xmlser = new XmlSerializer(typeof(FormParametrs));

            using (fileStream = new FileStream(fileName, FileMode.Create))
            {
                xmlser.Serialize(fileStream, formParametrs);
            }
        }

        private FormParametrs LoadParametrs()
        {
            XmlSerializer xmldeserializer = new XmlSerializer(typeof(FormParametrs));
            if (File.Exists(fileName))
            {
                using (reader = new StreamReader(fileName))
                {
                    FormParametrs formParams = new FormParametrs();
                    try
                    {
                        formParams = (FormParametrs)xmldeserializer.Deserialize(reader);
                    }
                    catch (Exception e)
                    {
                        message.ShowMessage(e.Message);
                    }
                    return formParams;
                }
            }
            else
            {
                message.ShowMessage("cannot find filename launch with default params");
                return formParametrs.DefaultParametrs();
            }
        }

        private void FillIncrementList()
        {
            double beginValue = 0.1;
            var incrementItems = incrementList.Items;

            for (int i = 0; i < 10; i++)
            {
                incrementItems.Add("dx = " + beginValue);
                beginValue += i + 1;

            }

            incrementList.SelectedIndex = 2;
        }

        #region Wizzard master
        private void Master(int step)
        {
            switch (step)
            {
                case 1:
                    {
                        this.Text = $"Step {currentStep} of {maxSteps}";

                        previousStepButton.Enabled = false;
                        nextStepButton.Enabled = true;

                        welcomeLinkLabel.Click += new EventHandler(welcomeLinkLabel_Click);
                        AddControll(welcomeLinkLabel, "welcome to graphic wizzard. Click me", 112, 126, 183, 13);

                        break;
                    }

                case 2:
                    {
                        this.Text = $"Step {currentStep} of {maxSteps}";

                        previousStepButton.Enabled = true;
                        nextStepButton.Enabled = true;

                        AddControll(header, "Choice the function", 137, 50, 102, 13);

                        AddControll(formula1, "y = x*x + tg(5x+b/x)", 58, 79, 116, 17);
                        formula1.Checked = true;
                        AddControll(formula2, "y = 0.1*a*x^3 * tg(a-b*x)", 58, 167, 137, 17);
                        formula1.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);

                        break;
                    }
                case 3:
                    {
                        this.Text = $"Step {currentStep} of {maxSteps}";

                        previousStepButton.Enabled = true;
                        nextStepButton.Enabled = true;

                        AddControll(xFirstValueLabel, "X first", 55, 82, 60, 13);
                        AddControll(xLastValueLabel, "X Last Value", 55, 169, 60, 13);

                        AddControll(bValueLabel, "b coeff", 55, 246, 40, 13);
                        AddControll(aValueLabel, "a coeff", 55, 318, 60, 13);

                        AddControll(xFirstValue, "", 213, 79, 100, 20);
                        xFirstValue.MaxLength = textBoxMaxNumbers;
                        xFirstValue.Validating += new CancelEventHandler(xFirstValue_Validating);

                        AddControll(xLastValue, "", 213, 157, 100, 20);
                        xLastValue.MaxLength = textBoxMaxNumbers;
                        xLastValue.Validating += new CancelEventHandler(xLastValue_Validating);

                        AddControll(bValue, "", 213, 239, 100, 20);
                        bValue.MaxLength = textBoxMaxNumbers;
                        bValue.Validating += new CancelEventHandler(bValue_Validating);

                        AddControll(aValue, "", 213, 311, 100, 20);
                        aValue.MaxLength = textBoxMaxNumbers;
                        aValue.Validating += new CancelEventHandler(aValue_Validating);

                        if (isFirstChecked)
                        {
                            aValue.Enabled = false;
                        }
                        else
                        {
                            aValue.Enabled = true;
                        }

                        break;
                    }
                case 4:
                    {
                        this.Text = $"Step {currentStep} of {maxSteps}";

                        UnDisposeControll(incrementList);

                        previousStepButton.Enabled = true;
                        nextStepButton.Enabled = true;

                        incrementAdder.MaxLength = textBoxMaxNumbers;
                        AdderButton.Click += AdderButton_Click;
                        AddControll(incrementAdder, "", 89, 228, 120, 20);

                        incrementAdder.Validating += new CancelEventHandler(incrementAdder_Validating);

                        AddControll(AdderButton, "Add to list", 109, 263, 75, 23);

                        break;
                    }
                case 5:
                    {
                        this.Text = $"Step {currentStep} of {maxSteps}";

                        previousStepButton.Enabled = true;
                        nextStepButton.Enabled = false;

                        colorDialog1.AllowFullOpen = false;
                        colorDialog1.ShowHelp = true;

                        a = ExtractDoubleFromString(aValue.Text);

                        try
                        {
                            x1 = double.Parse(xFirstValue.Text);
                            x2 = double.Parse(xLastValue.Text);
                            b = double.Parse(bValue.Text);
                            dx = ExtractDoubleFromString(incrementList.SelectedItem.ToString());
                        }

                        catch (FormatException fe)
                        {
                            message.ShowMessage(fe.Message);

                            Disposer(currentStep);
                            currentStep = 1;
                            UnDisposer(currentStep);
                            Master(currentStep);
                        }


                        ClearPointChart();

                        if (colorDialog1.ShowDialog() == DialogResult.OK)
                        {
                            graphicChart.CalculateAndBuild(x1, x2, b, dx, chart1, "Series1", colorDialog1.Color, SeriesChartType.Line, a);
                        }

                        else
                        {
                            graphicChart.CalculateAndBuild(x1, x2, b, dx, chart1, "Series1", Color.Red, SeriesChartType.Line, a);
                        }

                        break;
                    }
            }
        }
        #endregion

        private CheckedListBox CreateIncrementList()
        {
            incrementList.CheckOnClick = true;

            incrementList.ItemCheck += incrementList_ItemCheck;


            AddControll(incrementList, null, 89, 50, 120, 154);

            FillIncrementList();

            return incrementList;
        }


        private Control AddControll(Control controll, string text, int pointX, int pointY, int? width = null, int? heigth = null)
        {
            controll.Text = text;
            this.Controls.Add(controll);
            controll.Location = new Point(pointX, pointY);

            if (width == null || heigth == null)
            {
                controll.Size = this.DefaultSize;
            }
            else
            {
                controll.Size = new Size(width.Value, heigth.Value);

            }

            return controll;
        }

        private void UnDisposer(int step)
        {
            switch (step)
            {
                case 1:
                    {
                        UnDisposeControll(welcomeLinkLabel);
                        break;
                    }
                case 2:
                    {
                        UnDisposeControll(header);
                        UnDisposeControll(formula1);
                        UnDisposeControll(formula2);
                        break;
                    }
                case 3:
                    {
                        UnDisposeControll(xFirstValueLabel);
                        UnDisposeControll(xFirstValue);

                        UnDisposeControll(xLastValueLabel);
                        UnDisposeControll(xLastValue);

                        UnDisposeControll(bValueLabel);
                        UnDisposeControll(bValue);

                        UnDisposeControll(aValueLabel);
                        UnDisposeControll(aValue);
                        break;
                    }
                case 4:
                    {
                        UnDisposeControll(incrementList);
                        UnDisposeControll(incrementAdder);

                        UnDisposeControll(AdderButton);
                        break;
                    }
                case 5:
                    {
                        UnDisposeControll(chart1);
                        break;
                    }
            }
        }

        private void Disposer(int step)
        {
            switch (step)
            {
                case 1:
                    {
                        DisposeControll(welcomeLinkLabel);
                        break;
                    }
                case 2:
                    {
                        DisposeControll(header);
                        DisposeControll(formula1);
                        DisposeControll(formula2);
                        break;
                    }
                case 3:
                    {

                        DisposeControll(xFirstValueLabel);
                        DisposeControll(xFirstValue);

                        DisposeControll(xLastValueLabel);
                        DisposeControll(xLastValue);

                        DisposeControll(bValueLabel);
                        DisposeControll(bValue);

                        DisposeControll(aValueLabel);
                        DisposeControll(aValue);
                        break;
                    }
                case 4:
                    {
                        DisposeControll(incrementList);
                        DisposeControll(incrementAdder);

                        DisposeControll(AdderButton);
                        break;
                    }
                case 5:
                    {
                        DisposeControll(chart1);
                        break;
                    }
            }
        }

        private void UnDisposeControll(Control controll)
        {
            controll.Visible = true;
        }

        private void DisposeControll(Control controll)
        {
            controll.Visible = false;
        }


        #endregion

        #region events

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool isSaveRezult = message.YesNo("Auto saving. Are you sure?", "Progress be saved");

            if (isSaveRezult)
            {
                Serialize();
                this.Dispose();
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void nextStepButton_Click(object sender, EventArgs e)
        {

            Disposer(currentStep);

            currentStep++;

            UnDisposer(currentStep);

            Master(currentStep);

        }

        private void previousStepButton_Click(object sender, EventArgs e)
        {
            Disposer(currentStep);

            currentStep--;

            UnDisposer(currentStep);

            Master(currentStep);
        }

        private void welcomeLinkLabel_Click(object sender, EventArgs e)
        {
            Disposer(currentStep);

            currentStep++;

            Master(currentStep);
        }

        private void incrementList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue != CheckState.Checked)
            {
                return;
            }

            // Get the items that are selected
            CheckedListBox.CheckedIndexCollection selectedItems = this.incrementList.CheckedIndices;

            // Check that we have at least 1 item selected
            if (selectedItems.Count > 0)
            {
                // Uncheck the other item
                this.incrementList.SetItemChecked(selectedItems[0], false);
            }
            if (selectedItems.Count == 0)
            {
                AdderButton.Enabled = true;
            }
        }

        private void AdderButton_Click(object sender, EventArgs e)
        {
            double value = 0;
            try
            {
                value = double.Parse(incrementAdder.Text);
            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message);
            }

            int index = incrementList.FindString("dx = " + incrementAdder.ToString(), 0);

            if (index != -1)
            {
                incrementList.SetSelected(index, true);
                MessageBox.Show("The value " + incrementAdder.ToString() + " is has already added in list");

                incrementAdder.Text = "";
                return;
            }
            else
            {
                incrementList.Items.Add("dx = " + incrementAdder.Text);
            }
        }

        private void xFirstValue_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                double x0 = double.Parse(xFirstValue.Text);
                errorMessage.ShowMessage(errorProvider1, xFirstValue);

                nextStepButton.Enabled = true;

            }

            catch (FormatException)
            {
                errorMessage.ShowMessage(errorProvider1, xFirstValue, "Not a value.");
                nextStepButton.Enabled = false;
            }
        }

        private void aValue_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                double x0 = double.Parse(aValue.Text);
                errorMessage.ShowMessage(errorProvider1, aValue);

                nextStepButton.Enabled = true;

            }

            catch (FormatException)
            {
                errorMessage.ShowMessage(errorProvider1, aValue, "Not a value.");
                nextStepButton.Enabled = false;
            }
        }

        private void bValue_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                double x0 = double.Parse(bValue.Text);
                errorMessage.ShowMessage(errorProvider1, bValue);

                nextStepButton.Enabled = true;
            }

            catch (FormatException)
            {
                errorMessage.ShowMessage(errorProvider1, bValue, "Not a value.");
                nextStepButton.Enabled = false;
            }
        }

        private void xLastValue_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                double x0 = double.Parse(xLastValue.Text);
                errorMessage.ShowMessage(errorProvider1, xLastValue);

                nextStepButton.Enabled = true;

            }

            catch (FormatException)
            {
                errorMessage.ShowMessage(errorProvider1, xLastValue, "Not a value.");
                nextStepButton.Enabled = false;
            }
        }

        private void incrementAdder_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                double x0 = double.Parse(incrementAdder.Text);
                errorMessage.ShowMessage(errorProvider1, incrementAdder);
            }

            catch (FormatException)
            {
                errorMessage.ShowMessage(errorProvider1, incrementAdder, "Not a value.");
            }

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Disposer(currentStep);
            currentStep = 1;
            Master(currentStep);
            UnDisposer(currentStep);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Disposer(currentStep);
            currentStep = 2;
            Master(currentStep);
            UnDisposer(currentStep);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Disposer(currentStep);
            currentStep = 3;

            Master(currentStep);
            UnDisposer(currentStep);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Disposer(currentStep);
            currentStep = 4;
            Master(currentStep);
            UnDisposer(currentStep);
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if (formula1.Checked)
            {
                isFirstChecked = true;
            }
            else
            {
                isFirstChecked = false;
            }
        }

        private void lastParamsButton_Click(object sender, EventArgs e)
        {
            FormParametrs formParams = LoadParametrs();

            isFirstChecked = formParams.isFirstFormula;
            xFirstValue.Text = formParams.xFirstValue.ToString();
            xLastValue.Text = formParams.xLastValue.ToString();
            bValue.Text = formParams.b.ToString();
            aValue.Text = formParams.a.ToString();
            selectedItem = formParams.dx;

            if (formParams.width != 0 || formParams.heigth != 0)
            {
                Size = new Size(formParams.width, formParams.heigth);

            }
            else
            {
                Size = DefaultMinimumSize;
            }

            isDeserialize = true;

            if ((string.IsNullOrWhiteSpace(xFirstValue.Text) || xFirstValue.Text == "0") || (string.IsNullOrWhiteSpace(xLastValue.Text) || xLastValue.Text == "0") || (string.IsNullOrWhiteSpace(bValue.Text) || bValue.Text == "0") || (string.IsNullOrWhiteSpace(selectedItem.ToString()) || selectedItem == 0))
            {
                message.ShowMessage("Some values are not corrected. Please reenter values");
                Disposer(currentStep);
                currentStep = 2;
                Master(currentStep);
            }
            else
            {
                Disposer(currentStep);
                currentStep = 5;
                UnDisposer(currentStep);
                Master(currentStep);

            }

        }

        #endregion
    }
}
