using static System.Net.WebRequestMethods;

namespace LetterBoxedDupe
{
    public partial class MainPage : ContentPage
    {
        private const string API_KEY = "ec13022";
        private const string API_URL = "https://www.omdbapi.com/";

        private Movie _movie; 

        public MainPage(Movie movie)
        {
            InitializeComponent();
            _movie = movie;
            LoadMovieDetails();
        }

        

        
        
    }

}
