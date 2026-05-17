using Lab_3_OOP_MAUI;

namespace Lab_3_OOP_MAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly DatabaseService _databaseService;

        public MainPage()
        {
            InitializeComponent();

            _databaseService = new DatabaseService();
        }

        public MainPage(DatabaseService databaseService)
        {
            InitializeComponent();

            _databaseService = databaseService;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            BooksCollection.ItemsSource = await _databaseService.GetBooksAsync();
        }

        private async void OnAddBookClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddBookPage(_databaseService));
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var button = sender as Button;

            var book = button.BindingContext as Book;

            await _databaseService.DeleteBookAsync(book);

            BooksCollection.ItemsSource = await _databaseService.GetBooksAsync();
        }
        private async void OnEditClicked(object sender, EventArgs e)
        {
            var button = sender as Button;

            var book = button.BindingContext as Book;

            await Navigation.PushAsync(new AddBookPage(_databaseService, book));
        }
    }
}
