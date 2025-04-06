using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using LetterBoxedDupe.Models;

namespace LetterBoxedDupe;

public partial class ReviewPage : ContentPage
{
    private readonly Movie _movie;
    private static readonly Dictionary<string, List<string>> Reviews = new Dictionary<string, List<string>>();

    public ReviewPage(Movie movie)
    {
        InitializeComponent();
        _movie = movie;
        if (_movie.Title != null)
        {
            MovieTitle.Text = _movie.Title;
            LoadReviews();
        }
        else
        {
            // Handle the case where the movie title is null
            MovieTitle.Text = "Unknown Title";
        }
    }

    private void OnSubmitReview(object sender, EventArgs e)
    {
        string review = ReviewEntry.Text;
        if (!string.IsNullOrEmpty(review))
        {
            if (_movie.Title != null)
            {
                if (!Reviews.ContainsKey(_movie.Title))
                {
                    Reviews[_movie.Title] = new List<string>();
                }
                Reviews[_movie.Title].Add(review);
            }
            ReviewEntry.Text = "";
            LoadReviews();
        }
        else { LoadReviews(); }
    }

    private void LoadReviews()
    {
        if (_movie.Title != null && Reviews.TryGetValue(_movie.Title, out var movieReviews))
        {
            ReviewList.ItemsSource = Reviews[_movie.Title];
        }
        else 
        {
            ReviewList.ItemsSource = new List<string> { "No reviews" };
        }
    }

}