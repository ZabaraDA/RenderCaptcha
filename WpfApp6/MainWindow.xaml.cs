using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Globalization;

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


namespace WpfApp6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random randomСoordinates = new Random();
        List<(int x, int y)> coordinatesList = new List<(int x, int y)>();

        string captchaContentString;
        bool correctCoordinatesBool = false;
        string symbolString;
        int xC;
        int yC;
        int distant = 50;

        int x1;
        int y1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            grd.Children.Clear();
            coordinatesList.Add((randomСoordinates.Next(700), randomСoordinates.Next(700)));

            for (int i = 0; i < 10; i++)
            {
                symbolString = "";
                captchaContentString += symbolString += (char)randomСoordinates.Next(1040, 1104);

                Line directionLine = new Line();

                directionLine.Stroke = System.Windows.Media.Brushes.Black;

                directionLine.X1 = coordinatesList[i].x;
                directionLine.Y1 = coordinatesList[i].y;

                correctCoordinatesBool = false;
                while (correctCoordinatesBool != true)
                {
                    xC = randomСoordinates.Next(700);
                    for (int j = 0; j < coordinatesList.Count; )
                    {
                       
                        if (xC + distant < coordinatesList[j].x || xC - distant > coordinatesList[j].x)
                        {
                            j++;
                            correctCoordinatesBool = true;
                        }
                        else
                        {
                            correctCoordinatesBool = false;
                            break; 
                        }
                    }
                }
                correctCoordinatesBool = false;
                while (correctCoordinatesBool != true)
                {
                    yC = randomСoordinates.Next(700);
                    for (int j = 0; j < coordinatesList.Count;)
                    {
                        
                        if (yC + distant < coordinatesList[j].y || yC - distant > coordinatesList[j].y)
                        {
                            j++;
                            correctCoordinatesBool = true;

                        }
                        else
                        {
                            correctCoordinatesBool = false;
                            break;

                        }
                    }
                }

                lw.ItemsSource = coordinatesList.ToList();
                    tb.Text = xC.ToString() + " " + yC.ToString();
                coordinatesList.Add((xC, yC));

                //coordinatesList.Add((randomСoordinates.Next(500), randomСoordinates.Next(500)));

                directionLine.X2 = coordinatesList[i + 1].x;
                directionLine.Y2 = coordinatesList[i + 1].y;

                FormattedText formattedText = new FormattedText(
                    symbolString,
                    CultureInfo.GetCultureInfo("en-us"),
                    FlowDirection.LeftToRight,
                    new Typeface(new System.Windows.Media.FontFamily(),
                    FontStyles.Italic,
                    FontWeights.Bold,
                    FontStretches.Normal),
                    24, Brushes.Black,
                    VisualTreeHelper.GetDpi(this).PixelsPerDip);

                Geometry symbolGeometry = formattedText.BuildGeometry(new System.Windows.Point(directionLine.X1, directionLine.Y1));

                var symbolPath = new Path();
                symbolPath.Stroke = System.Windows.Media.Brushes.Black;
                symbolPath.Fill = System.Windows.Media.Brushes.MediumSlateBlue;
                symbolPath.Data = symbolGeometry;

                grd.Children.Add(symbolPath);
                grd.Children.Add(directionLine);
            }
            coordinatesList.Clear();
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
                bool a = true;
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

            //FormattedText formattedText1 = new FormattedText(aa,
            //    CultureInfo.GetCultureInfo("en-us"),
            //      FlowDirection.LeftToRight,
            //       new Typeface(
            //            new System.Windows.Media.FontFamily(),
            //            FontStyles.Italic,
            //            FontWeights.Bold,
            //            FontStretches.Normal),
            //            24, Brushes.Black);

        }
    }
    //public partial class Сoordinates
    //{
    //    int x { get; set; }
    //    int y { get; set; }

    //    public Coordinates(int xx, int yy)
    //    {
    //        x = xx;
    //        y = yy;
    //    }

    //}



}
