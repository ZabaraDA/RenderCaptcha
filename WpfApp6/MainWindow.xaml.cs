using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Brushes = System.Windows.Media.Brushes;
using Path = System.Windows.Shapes.Path;

namespace WpfApp6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random randomСoordinates = new Random();

        string s;
        bool a = true;
        int y1;
        int x1;
        public MainWindow()
        {
            InitializeComponent();

        }



        [Obsolete]
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            grd.Children.Clear();
            for (int i = 0; i < 20; i++)
            {
                string aa = "";
                s += aa += (char)(randomСoordinates.Next(1040, 1104));

                Line objline = new Line();

                objline.Stroke = System.Windows.Media.Brushes.Black;
                objline.Fill = System.Windows.Media.Brushes.Black;

                int xLine = randomСoordinates.Next(500);
                int yLine = randomСoordinates.Next(500);

                if (a == true)
                {
                    objline.X1 = 50;
                    objline.Y1 = 50;
                    a = false;
                }
                else
                {
                    objline.X1 = x1;
                    objline.Y1 = y1;
                }

                objline.X2 = xLine;
                objline.Y2 = yLine;
                x1 = xLine;
                y1 = yLine;

                FormattedText formattedText = new FormattedText(aa,
                CultureInfo.GetCultureInfo("en-us"),
                  FlowDirection.LeftToRight,
                   new Typeface(
                        new System.Windows.Media.FontFamily(),
                        FontStyles.Italic,
                        FontWeights.Bold,
                        FontStretches.Normal),
                        24, Brushes.Black);

                Geometry geometry = formattedText.BuildGeometry(new System.Windows.Point(objline.X1, objline.Y1));

                var myPath = new Path();
                myPath.Stroke = System.Windows.Media.Brushes.Black;
                myPath.Fill = System.Windows.Media.Brushes.MediumSlateBlue;
                myPath.StrokeThickness = 1;
                myPath.Data = geometry;

                grd.Children.Add(myPath);
                grd.Children.Add(objline);


            }

        }

        private void addButton_Click1(object sender, RoutedEventArgs e)
        {
            Line objline = new Line();
            objline.Stroke = System.Windows.Media.Brushes.Black;
            objline.Fill = System.Windows.Media.Brushes.Black;

            objline.X1 = addButton.ActualWidth;
            objline.Y1 = addButton.ActualHeight;

            objline.X2 = Application.Current.MainWindow.Width;
            objline.Y2 = Application.Current.MainWindow.Height;

            grd.Children.Add(objline);

        }
        [Obsolete]
        public string Text2Path()
        {
            FormattedText formattedText = new FormattedText("Any text you like",
                CultureInfo.GetCultureInfo("en-us"),
                  FlowDirection.LeftToRight,
                   new Typeface(
                        new System.Windows.Media.FontFamily(),
                        FontStyles.Italic,
                        FontWeights.Bold,
                        FontStretches.Normal),
                        16, Brushes.Black);

            Geometry geometry = formattedText.BuildGeometry(new System.Windows.Point(0, 0));

            System.Windows.Shapes.Path path = new System.Windows.Shapes.Path();
            path.Data = geometry;

            string geometryAsString = geometry.GetFlattenedPathGeometry().ToString().Replace(",", ".").Replace(";", ",");
            return geometryAsString;
        }
        [Obsolete]
        private void addButton_Click2(object sender, RoutedEventArgs e)
        {
            grd.Children.Clear();
            for (int i = 0; i < 10; i++)
            {

                Line objline = new Line();

                FormattedText formattedText = new FormattedText("Any text you like",
                CultureInfo.GetCultureInfo("en-us"),
                  FlowDirection.LeftToRight,
                   new Typeface(
                        new System.Windows.Media.FontFamily(),
                        FontStyles.Italic,
                        FontWeights.Bold,
                        FontStretches.Normal),
                        16, Brushes.Black);

                Geometry geometry = formattedText.BuildGeometry(new System.Windows.Point(x1, y1));

                var myPath = new Path();
                myPath.Stroke = System.Windows.Media.Brushes.Black;
                myPath.Fill = System.Windows.Media.Brushes.MediumSlateBlue;
                myPath.StrokeThickness = 1;
                myPath.HorizontalAlignment = HorizontalAlignment.Left;
                myPath.VerticalAlignment = VerticalAlignment.Center;
                EllipseGeometry myEllipseGeometry = new EllipseGeometry();
                myEllipseGeometry.Center = new System.Windows.Point(x1, y1);
                myEllipseGeometry.RadiusX = 5;
                myEllipseGeometry.RadiusY = 5;
                myPath.Data = geometry;
                grd.Children.Add(myPath);



                objline.Stroke = System.Windows.Media.Brushes.Black;
                objline.Fill = System.Windows.Media.Brushes.Black;

                int xLine = randomСoordinates.Next(400);
                int yLine = randomСoordinates.Next(400);
                if (a == true)
                {
                    objline.X1 = addButton.ActualWidth;
                    objline.Y1 = addButton.ActualHeight;
                    a = false;
                }
                else
                {
                    objline.X1 = x1;
                    objline.Y1 = y1;
                }

                objline.X2 = xLine;
                objline.Y2 = yLine;
                x1 = xLine;
                y1 = yLine;

                grd.Children.Add(objline);


            }

        }
    }




}
