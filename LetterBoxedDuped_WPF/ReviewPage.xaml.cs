using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LetterBoxedDuped_WPF
{
    /// <summary>
    /// Interaction logic for ReviewPage.xaml
    /// </summary>
    public partial class ReviewPage : Page
    {
        private readonly Action _onBack;
        public ReviewPage(string movieTitle, string PosterImage ,Action onBack)
        {
            InitializeComponent();
            MovieTitleBlck.Text = $"Review For the Movie: {movieTitle}";
            _onBack = onBack;

        }

        private void SaveReview_Click(object sender, RoutedEventArgs e)
        {
           string review = ReviewTextBx.Text.Trim();
            if (!string.IsNullOrEmpty(review))
            {
                using (var db = new ReviewDbContent())
                {
                    db.Reviews.Add(new Reviews
                    {
                        MovieTitle = MovieTitleBlck.Text,
                        Review = review,
                        DateCreated = DateTime.Now
                    });
                    db.SaveChanges();
                }
                MessageBox.Show("Review saved successfully!");
                ReviewTextBx.Clear();
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            _onBack?.Invoke();
        }

    }
}
