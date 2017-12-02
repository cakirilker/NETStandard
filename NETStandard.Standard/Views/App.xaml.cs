using NETStandard.Standard.Data;
using NETStandard.Standard.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace NETStandard.Standard.Views
{
    public partial class App : Application
    {
        public static MovieManager MovieManager { get; private set; }
        public App()
        {
            InitializeComponent();

            // HttpClient is intended to be instantiated once and re-used throughout the life of an application. 
            // Especially in server applications, creating a new HttpClient instance for every request will exhaust the number of sockets available under heavy loads.
            // This will result in SocketException errors.
            MovieManager = new MovieManager(new MovieRestService());

            if (Device.RuntimePlatform == Device.iOS)
                MainPage = new MainPage();
            else
                MainPage = new NavigationPage(new MainPage());

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
