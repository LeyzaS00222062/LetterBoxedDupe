using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace LetterBoxedDupe;

public partial class MoviePage : ContentPage
{
    private const string API_KEY = "ec13022";
    private const string API_URL = "https://www.omdbapi.com/";

    private Movie _movie;

    public MoviePage(Movie movie)
	{
		InitializeComponent();
        _movie = movie;
        LoadMovieDetails();

        
    }

    private async void LoadMovieDetails()
    {
        using HttpClient client = new HttpClient();
        string url = $"{API_URL}?i={_movie.OmdbID}&apikey={API_KEY}";
        var response = await client.GetStringAsync(url);
        var movieDetails = JsonSerializer.Deserialize<MovieDetails>(response);

        MovieTitle.Text = movieDetails.Title;
        MovieYear.Text = $"Released: {movieDetails.Year}";
        MovieDescription.Text = movieDetails.Description;
        MoviePoster.Source = movieDetails.Poster;

    }
}