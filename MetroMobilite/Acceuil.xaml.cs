using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
using MyLibrary;

namespace MetroMobilite
{
    /// <summary>
    /// Logique d'interaction pour Acceuil.xaml
    /// </summary>
    public partial class Acceuil : Page, INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string pLongitude { get; set; }
        public string pLatitude { get; set; }
        public string pRayon { get; set; }

        public List<LinesDescription> StopLine { get; set; }

        public List<Lines> pLines { get; set; }

        ApiRequest apiRequest;


        public Acceuil()
        {
            InitializeComponent();

            apiRequest = new ApiRequest();

            pLongitude = "5.709360123";
            pLatitude = "45.1764946";
            pRayon = "350";

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            Home_Grid.DataContext = this;
        }

        private void doRequest(object sender, RoutedEventArgs e)
        {

            pLongitude = ReplaceACaractere(Longitude.Text);
            pLatitude = ReplaceACaractere(Latitude.Text);
            pRayon = Rayon.Text;

            pLines = apiRequest.getLines(Convert.ToDouble(pLongitude), Convert.ToDouble(pLatitude));

              grdStopLineData.ItemsSource = pLines;

        }

        private string ReplaceACaractere(string str)
        {
            if (str.Contains('.'))
            {
                return str;
            }
            else
            {
                return str.Replace(',', '.');
            }

        }

        private void grdStopLineData_Selected(object sender, RoutedEventArgs e)
        {
            StopLine = new List<LinesDescription>();

            Lines items = (Lines)grdStopLineData.SelectedItem;

            if (items != null)
            {
                foreach (string line in items.lines)
                {
                    if (line != null)
                    {
                        StopLine.Add(apiRequest.getLinesDescription(line)[0]);
                    }
                }
                grdLines.ItemsSource = StopLine;
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Maps Map = new Maps();

            this.NavigationService.Navigate(Map);
        }
    }
}
