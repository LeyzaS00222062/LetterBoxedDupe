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
    /// Interaction logic for ListReviews.xaml
    /// </summary>
    public partial class ListReviews : Page
    {
        private readonly Action _onBack;

        public ListReviews(Action onBack)
        {
            InitializeComponent();
            _onBack = onBack;
            LoadReviews();
        }

        private void LoadReviews()
        {
            using (var db = new ReviewDbContent())
            {
                List<Reviews> reviews = db.Reviews.OrderByDescending(r => r.DateCreated).ToList();
                ReviewsListBx.ItemsSource = reviews;
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            _onBack?.Invoke();
        }
    }
}
