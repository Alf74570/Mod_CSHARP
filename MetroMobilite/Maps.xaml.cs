using System;
using System.Collections.Generic;
using System.Linq;
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
using Microsoft.Maps.MapControl.WPF;

namespace MetroMobilite
{
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class Maps : Page
    {
       
        private void Maps_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // TODO
        }

        public Maps()
        {
            InitializeComponent();

            myMap.MouseDoubleClick += Maps_MouseDoubleClick;
            listBox1.Items.Add("Bing Maps control initialized");
            listBox1.Items.Add("");
        }
        
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Add("Center Zoom button clicked");
            listBox1.Items.Add("Centering map to 45.186768, 5.736153");
            listBox1.Items.Add("Setting zoom level to 17.0");
            listBox1.Items.Add("");
            myMap.Center = new Location(45.186768, 5.736153);
            myMap.ZoomLevel = 17.0;

            PlaceDot(new Location(45.186768, 5.736153), Colors.Red);
        }

        private void PlaceDot(Location location, Color color)
        {
            Ellipse dot = new Ellipse();
            dot.Fill = new SolidColorBrush(color);
            double radius = 12.0;
            dot.Width = radius * 2;
            dot.Height = radius * 2;
            ToolTip tt = new ToolTip();
            tt.Content = "Vous êtes ici \n" + location;
            dot.ToolTip = tt;
            Point p0 = myMap.LocationToViewportPoint(location);
            Point p1 = new Point(p0.X - radius, p0.Y - radius);
            Location loc = myMap.ViewportPointToLocation(p1);
            MapLayer.SetPosition(dot, loc);
            myMap.Children.Add(dot);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Add("Clear Map button clicked");
            int ct = myMap.Children.Count;
            myMap.Children.Clear();
            listBox1.Items.Clear();
            listBox1.Items.Add("Clearing " + ct + " items from map");
            listBox1.Items.Add("");
        }

    }
}
