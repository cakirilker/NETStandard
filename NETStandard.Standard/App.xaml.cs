using NETStandard.Standard.Data;
using NETStandard.Standard.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace NETStandard
{
    public partial class App : Application
    {
        public static MovieManager movieManager { get; private set; }
        public App()
        {
            InitializeComponent();

            movieManager = new MovieManager(new MovieRestService());
            MainPage = new NETStandard.MainPage();
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
