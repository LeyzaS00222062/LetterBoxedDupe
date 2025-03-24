using System.Collections.ObjectModel;

namespace LetterBoxedDupe;

public partial class MoviePage : ContentPage
{
    private ObservableCollection<string> _allItems;
    private ObservableCollection<string> _filteredItems;

    public MoviePage(string searchTerm)
	{
		InitializeComponent();

        _allItems = new ObservableCollection<string>
        {
            {searchTerm}
        };

        
        _filteredItems = new ObservableCollection<string>(
            _allItems.Where(item => item.ToLower().Contains(searchTerm.ToLower()))
        );

        
        resultsCollectionView.ItemsSource = _filteredItems;
    }
}