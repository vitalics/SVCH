using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        enum Tool
        {
            Rotate,
            Scale
        }
        enum ArrowKey
        {
            Up,
            Down,
            Left,
            Right,
            Other
        }

        private const byte DIFF_MOUSE_ANGLE = 24;
        private Tool activeTool = Tool.Rotate;
        private double offsetX = 5d;
        private double offsetY = 5d;
        double angle = 0;
        private const string GRID_UID = "gridUI";

        public MainWindow()
        {
            InitializeComponent();

            Bernuli.Margin = new Thickness(90, 100, 90, 100);

            RotateRadio.IsChecked = true;
            Graphic.MouseWheel += Bernuli_MouseWheel;
            Graphic.KeyDown += Bernuli_KeyDown;


        }

        private void rotateButton_Click(object sender, RoutedEventArgs e)
        {
            activeTool = Tool.Rotate;
        }

        private void scaleButton_Click(object sender, RoutedEventArgs e)
        {
            activeTool = Tool.Scale;
        }


        private void Bernuli_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    Move(ArrowKey.Left);
                    break;
                case Key.Up:
                    Move(ArrowKey.Up);
                    break;
                case Key.Right:
                    Move(ArrowKey.Right);
                    break;
                case Key.Down:
                    Move(ArrowKey.Down);
                    break;
                default:
                    Move(ArrowKey.Other);
                    break;
            }
        }

        private void Move(ArrowKey key)
        {
            
            switch (key)
            {
                case ArrowKey.Up:
                    betweenGraphicAndBernuli.RenderTransform = new TranslateTransform(offsetX, offsetY--);
                    break;
                case ArrowKey.Down:
                    betweenGraphicAndBernuli.RenderTransform = new TranslateTransform(offsetX, offsetY++);

                    break;
                case ArrowKey.Left:
                    betweenGraphicAndBernuli.RenderTransform = new TranslateTransform(offsetX--, offsetY);
                    break;
                case ArrowKey.Right:
                    betweenGraphicAndBernuli.RenderTransform = new TranslateTransform(offsetX++, offsetY);
                    break;
                case ArrowKey.Other:
                    //offsetX = offsetY = 0;
                    break;
                default:
                    break;
            }
        }


        private void Bernuli_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            switch (activeTool)
            {
                case Tool.Rotate:
                    Rotate(e);
                    break;
                case Tool.Scale:
                    Scale(e);
                    break;
                default:
                    break;
            }
        }

        private void Rotate(MouseWheelEventArgs e)
        {
            angle += e.Delta / DIFF_MOUSE_ANGLE;
            Bernuli.RenderTransform = new RotateTransform(angle);
        }

        private void Scale(MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                Bernuli.Width++;
                Bernuli.Height++;
            }
            else if (e.Delta <= 0)
            {
                Bernuli.Width--;
                Bernuli.Height--;
            }

        }
        private void Rotate2_Click(object sender, RoutedEventArgs e)
        {

            int baseAngle = 5;
            int offset = 5;


            RotateTransform rotateTransform = new RotateTransform();

            Bernuli.RenderTransform = rotateTransform;

            baseAngle = baseAngle + offset;
        }

        private void setGraphicColor(object sender, RoutedEventArgs e)
        {

            ColorDialog Col = new ColorDialog();
            DrawingBrush br = new DrawingBrush();
            if (Col.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var brash = System.Windows.Media.Color.FromArgb(Col.Color.A, Col.Color.R, Col.Color.G, Col.Color.B);

                Bernuli.Stroke = new SolidColorBrush(brash);
            }
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Bernuli_KeyDown(sender, e);
        }
    }
}
