using SQLite;

namespace Lab_3_OOP_MAUI;

public class Book
{
    [PrimaryKey, AutoIncrement]
    public int Id
    {
        get; set;
    }

    public string Title
    {
        get; set;
    }

    public string Author
    {
        get; set;
    }

    public string Genre
    {
        get; set;
    }

    public int Year
    {
        get; set;
    }

    public double Price
    {
        get; set;
    }
}