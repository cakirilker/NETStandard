using NETStandard.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NETStandard
{
    public partial class MainPage : ContentPage
    {
        bool alertShown = false;

        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (Constants.RestUrl.Contains("localhost"))
            {
                if (!alertShown)
                {
                    await DisplayAlert(
                        "Hosted Back-End",
                        "This app is running against Xamarin's read-only REST service. To create, edit, and delete data you must update the service endpoint to point to your own hosted REST service.",
                        "OK");
                    alertShown = true;
                }
            }

            listView.ItemsSource = await App.movieManager.GetMoviesAsync();
        }
    }
}
