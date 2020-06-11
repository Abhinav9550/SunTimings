
using System;
using System.Windows;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace SunTimings
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string url = "https://api.sunrise-sunset.org/json?lat=" + txtLatitude.Text + "&lng=" + txtLongitude.Text;
                SunOrganisation res = JsonConvert.DeserializeObject<SunOrganisation>(new WebClient().DownloadString(url));
                if (res.status == "OK")
                {
                    lblSunRise.Content = $" SunRise Time is at : {res.results.sunrise} ";
                    lblSunSet.Content = $" Sunset Time is at : {res.results.sunrise}";
                }
            }
            catch (Exception )
            {
                lblSunRise.Content = "Please enter valid values";
            }
        }

        public class SunOrganisation
        {
            public SunOrganisationResults results { get; set; }
            public string status { get; set; }
        }

        public class SunOrganisationResults
        {
            public string sunrise { get; set; }
            public string sunset { get; set; }
        }
    }
}