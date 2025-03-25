using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
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
                await FetchMoviesFromApi(searchMovie);

            }


        }
        private async Task FetchMoviesFromApi(string query)
        {
            using HttpClient client = new HttpClient();
            string url = $"{API_URL}?s={query}&apikey={API_KEY}";
            var response = await client.GetStringAsync(url);
            var movieData = JsonSerializer.Deserialize<OmdbSearchResult>(response);

            Movies.Clear();
            if (movieData?.Search != null) 
            {
                foreach (var movie in movieData.Search)
                {
                    Movies.Add(movie);
                }
            }
        }

        private async void OnMovieSelected(object sender, SelectedPositionChangedEventArgs e)
        {
            if (e.SelectedPosition.LoadFromXaml() is Movie selectedMovie)
            {
                await Navigation.PushAsync(new MoviePage(selectedMovie));
            }
        }
        
        
    }
    public class OmdbSearchResult
    {
        public List<Movie> Search { get; set; }
    }

}
