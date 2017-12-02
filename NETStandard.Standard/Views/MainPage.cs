using Xamarin.Forms;
using System;

namespace NETStandard.Standard.Views
{
    public class MainPage : TabbedPage
    {
        bool alertShown = false;

        public MainPage()
        {
            Page MoviesPage, AboutPage;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    MoviesPage = new NavigationPage(new MoviesPage())
                    {
                        Title = "Movies",
                        Icon = "today.png"
                    };
                    AboutPage = new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = "today.png"
                    };
                    break;

                default:
                    MoviesPage = new MoviesPage()
                    {
                        Title = "Movies"
                    };
                    AboutPage = new AboutPage()
                    {
                        Title = "About"
                    };
                    break;
            }
            Children.Add(MoviesPage);
            Children.Add(AboutPage);
            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (Constants.RestUrl.Contains("192.168.1.29"))
                if (!alertShown)
                {
                    await DisplayAlert(
                        "Welcome!",
                        "Xamarin.Forms application test with REST service.",
                        "OK");
                    alertShown = true;
                }
        }
    }
}
