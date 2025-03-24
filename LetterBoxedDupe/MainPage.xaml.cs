using Microsoft.UI.Xaml.Media.Animation;
using System.Collections.ObjectModel;
using Windows.ApplicationModel.Search;
using static System.Net.WebRequestMethods;

namespace LetterBoxedDupe
{
    public partial class MainPage : ContentPage
    {
        private const string API_KEY = "ec13022";
        private const string API_URL = "https://www.omdbapi.com/";

        public ObservableCollection<Movie> Movies { get; set; } = new ObservableCollection<Movie>();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void OnSearchMovies(object sender, EventArgs e)
        {
            string searchMovie = searchBarMovie.Text;
            if (string.IsNullOrEmpty(searchMovie))
            {
               

            }


        }
        private async Task FetchMoviesFromApi(string query)
        {
            using HttpClient client = new HttpClient();

        }
        
        
    }

}
