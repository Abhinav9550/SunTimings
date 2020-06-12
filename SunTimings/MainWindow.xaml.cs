
using System;
using System.Windows;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

namespace SunTimings
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
      


        public static string sunRiseResult = "";
        public static string sunSetResult = "";
        public static string[] res;
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                res = new WebClient().DownloadString("https://api.sunrise-sunset.org/json?lat=" + txtLatitude.Text + "&lng=" + txtLongitude.Text).Split('\"');

                Task.Run(() =>
                {
                    if (res.Contains("status") && res.Contains("OK"))
                    {
                        for (int i = 0; i < res.Length; i++)
                        {
                            if (res[i] == "sunrise")
                                sunRiseResult = $" SunRise Time is at : {Convert.ToDateTime(res[i + 2]).AddHours(5).AddMinutes(30).ToString("hh:mm tt")}";
                            if (res[i] == "sunset")
                                sunSetResult = $" Sunset Time is at : {Convert.ToDateTime(res[i + 2]).AddHours(5).AddMinutes(30).ToString("hh:mm tt")}";

                            this.Dispatcher.Invoke(() =>
                            {
                                lblSunRise.Content = sunRiseResult;
                                lblSunSet.Content = sunSetResult;
                            });
                        }
                    }
                });

            }
            catch (Exception)
            {
                lblSunRise.Content= "Please enter valid values";
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