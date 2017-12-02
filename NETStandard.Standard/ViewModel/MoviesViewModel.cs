using NETStandard.Standard.Model;
using NETStandard.Standard.Views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NETStandard.Standard.ViewModel
{
    public class MoviesViewModel : INotifyPropertyChanged
    {
        private bool _isBusy = false;
        private ObservableCollection<Movie> _movies;

        public MoviesViewModel()
        {
            Movies = new ObservableCollection<Movie>();
            MessagingCenter.Subscribe<NewMoviePage, Movie>(this, "AddMovie", async (obj, item) =>
               {
                   Movies.Add(item);
                   await App.MovieManager.CreateAsync(item);
               });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Not implemented yet.
        /// </summary>
        /// <returns></returns>
        async Task AddMovie() { }

        async Task GetAllMovies()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Movies.Clear();
                Movies = new ObservableCollection<Movie>(await App.MovieManager.GetAllAsync());
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public ICommand AddMovieCommand => new Command(async () => await AddMovie());
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadMoviesCommand => new Command(async () => await GetAllMovies());
        public ObservableCollection<Movie> Movies
        {
            get => _movies;
            set
            {
                _movies = value;
                OnPropertyChanged();
            }
        }
    }
}
