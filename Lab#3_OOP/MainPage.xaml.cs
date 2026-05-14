using Lab_3_OOP;
using Lab_3_OOP.Services;

namespace CrudApp;

public partial class MainPage : ContentPage
{
    private readonly DatabaseService _databaseService;

    public MainPage()
    {
        InitializeComponent();
    }

    public MainPage(DatabaseService databaseService)
    {
        InitializeComponent();

        _databaseService = databaseService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        BooksCollection.ItemsSource =
            await _databaseService.GetBooksAsync();
    }

    private async void OnAddBookClicked(
        object sender,
        EventArgs e)
    {
        await Navigation.PushAsync(new AddBookPage());
    }

    private async void OnDeleteClicked(
        object sender,
        EventArgs e)
    {
        var button = sender as Button;

        var book = button.BindingContext as Book;

        await _databaseService.DeleteBookAsync(book);

        BooksCollection.ItemsSource =
            await _databaseService.GetBooksAsync();
    }
}