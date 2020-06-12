
using System;
using System.Windows;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace SunTimings
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private  void  SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {             

                var res = new WebClient().DownloadString("https://api.sunrise-sunset.org/json?lat=" + txtLatitude.Text + "&lng=" + txtLongitude.Text).Split('\"');

                for (int i = 0; i < res.Length; i++)
                {
                    if (res[i] == "sunrise")
                        lblSunRise.Content = $" SunRise Time is at : {Convert.ToDateTime(res[i + 2]).AddHours(5).AddMinutes(30).ToString("hh:mm tt")}";
                    if (res[i] == "sunset")
                        lblSunSet.Content = $" Sunset Time is at : {Convert.ToDateTime(res[i + 2]).AddHours(5).AddMinutes(30).ToString("hh:mm tt")}";

                }
            }
            catch (Exception)
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