namespace Lab_3_OOP_MAUI;

public partial class AddBookPage : ContentPage
{
    private readonly DatabaseService _databaseService;

    private Book _book;

    public AddBookPage(DatabaseService databaseService)
    {
        InitializeComponent();

        _databaseService = databaseService;

        Title = "Add Book";
    }

    public AddBookPage(DatabaseService databaseService, Book book)
    {
        InitializeComponent();

        _databaseService = databaseService;

        _book = book;

        Title = "Edit Book";

        TitleEntry.Text = book.Title;
        AuthorEntry.Text = book.Author;
        GenreEntry.Text = book.Genre;
        YearEntry.Text = book.Year.ToString();
        PriceEntry.Text = book.Price.ToString();
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TitleEntry.Text))
        {
            await DisplayAlert(
                "Error",
                "Title cannot be empty",
                "OK");

            return;
        }

        if (string.IsNullOrWhiteSpace(AuthorEntry.Text))
        {
            await DisplayAlert(
                "Error",
                "Author cannot be empty",
                "OK");

            return;
        }

        if (!int.TryParse(YearEntry.Text, out int year))
        {
            await DisplayAlert(
                "Error",
                "Invalid year",
                "OK");

            return;
        }

        if (year < 0 || year > DateTime.Now.Year)
        {
            await DisplayAlert(
                "Error",
                "Year is incorrect",
                "OK");

            return;
        }

        if (!double.TryParse(PriceEntry.Text, out double price))
        {
            await DisplayAlert(
                "Error",
                "Invalid price",
                "OK");

            return;
        }

        if (price < 0)
        {
            await DisplayAlert(
                "Error",
                "Price cannot be negative",
                "OK");

            return;
        }

        if (_book == null)
        {
            _book = new Book();
        }

        _book.Title = TitleEntry.Text;
        _book.Author = AuthorEntry.Text;
        _book.Genre = GenreEntry.Text;
        _book.Year = year;
        _book.Price = price;

        await _databaseService.SaveBookAsync(_book);

        await Navigation.PopAsync();
    }
}