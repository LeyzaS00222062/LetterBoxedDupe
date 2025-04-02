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
    private Movie _movie;
    private static Dictionary<string, List<string>> Reviews = new Dictionary<string, List<string>>();

    public ReviewPage(Movie movie)
    {
        InitializeComponent();
        _movie = movie;
        MovieTitle.Text = movie.Title;
        LoadReviews();
    }

    private void OnSubmitReview(object sender, EventArgs e)
    {
        string review = ReviewEntry.Text;
        if (!string.IsNullOrWhiteSpace(review))
        {
            if (!Reviews.ContainsKey(_movie.Title))
            {
                Reviews[_movie.Title] = new List<string>();
            }
            Reviews[_movie.Title].Add(review);
            ReviewEntry.Text = "";
            LoadReviews();
        }
    }

    private void LoadReviews()
    {
        if (Reviews.ContainsKey(_movie.Title))
        {
            ReviewList.ItemsSource = Reviews[_movie.Title];
        }
    }

}