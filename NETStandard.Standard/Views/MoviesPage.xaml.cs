using NETStandard.Standard.Model;
using NETStandard.Standard.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NETStandard.Standard.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesPage : ContentPage
    {
        MoviesViewModel viewModel;

        public MoviesPage()
        {
            InitializeComponent();
            viewModel = new MoviesViewModel();
            BindingContext = viewModel;
        }

        protected  override void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel.Movies.Count == 0)
                viewModel.LoadMoviesCommand.Execute(null);
        }

        async void OnMovieSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Movie;

            if (item == null)
                return;
            await DisplayAlert("Movie Tapped", "An item was tapped.", "OK");

            MoviesListView.SelectedItem = null;
        }

        async void AddNewMovie(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewMoviePage());
        }
    }
}
