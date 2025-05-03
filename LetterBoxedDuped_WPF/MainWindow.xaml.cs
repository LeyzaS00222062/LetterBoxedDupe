using System.Net.Http;
using System.Text;
using System.Text.Json;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string API_KEY = "ec13022";
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            string searchTitle = SearchBx.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchTitle)) return;
            
            using HttpClient client = new HttpClient();
            string url = $"https://www.omdbapi.com/?t={searchTitle}&apikey={API_KEY}";
            string json = await client.GetStringAsync(url);

            using JsonDocument jsonDoc = JsonDocument.Parse(json);
            JsonElement root = jsonDoc.RootElement;

            if (root.TryGetProperty("Response", out JsonElement response) && response.GetString() == "False")
            {
                MessageBox.Show("Movie not found");
                return;
            }

            TitleBlock.Text = root.GetProperty("Title").GetString();
            YearBlock.Text = "Year: " + root.GetProperty("Year").GetString();
            GenreBlock.Text = "Genre: " + root.GetProperty("Genre").GetString();
            PlotBlock.Text = "Plot: " + root.GetProperty("Plot").GetString();
            RatingBlock.Text = "Rating: " + root.GetProperty("imdbRating").GetString();

            string posterUrl = root.GetProperty("Poster").GetString();
            if (posterUrl != "N/A")
            {
                PosterImage.Source = new BitmapImage(new Uri(posterUrl));
            }
            else
            { 
                PosterImage.Source = null;
            }
            //MessageBox.Show("Search button clicked!");

        }

        private void ToReviewPage_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TitleBlock.Text))
            {
                MessageBox.Show("Please search for a movie first.");
                return;
            }

            ReviewFrame.Visibility = Visibility.Visible;
            MainGrid.Visibility = Visibility.Collapsed;
            string posterUrl = PosterImage.Source != null ? ((BitmapImage)PosterImage.Source).UriSource.ToString() : "N/A";
            ReviewFrame.Navigate(new ReviewPage(TitleBlock.Text, posterUrl ,CloseReviewPage));
        }
        
        private void CloseReviewPage()
        {
            ReviewFrame.Visibility = Visibility.Collapsed;
            MainGrid.Visibility = Visibility.Visible;
            TitleBlock.Text = string.Empty;
            YearBlock.Text = string.Empty;
            GenreBlock.Text = string.Empty;
            PlotBlock.Text = string.Empty;
            RatingBlock.Text = string.Empty;
            PosterImage.Source = null;
        }



    }
}