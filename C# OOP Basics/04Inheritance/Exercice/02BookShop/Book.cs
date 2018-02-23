using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Book
{
    private string author;
    private string title;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public string Author
    {
        get { return author; }
        set
        {
            if (value.Split().Length > 1)
            {
                var splitterIndex = value.IndexOf(' ');
                if (char.IsDigit(value[splitterIndex + 1]) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Author not valid!");
                }
            }
            author = value;
        }
    }

    public string Title
    {
        get { return title; }
        set
        {
            if (value.Length < 3 || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Title not valid!");
            }
            title = value;
        }
    }

    public virtual decimal Price
    {
        get { return price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            price = value;
        }
    }

    public override string ToString()
    {
        var resultBuilder = new StringBuilder();
        resultBuilder.AppendLine($"Type: {this.GetType().Name}")
            .AppendLine($"Title: {this.Title}")
            .AppendLine($"Author: {this.Author}")
            .AppendLine($"Price: {this.Price:F2}");

        string result = resultBuilder.ToString().TrimEnd();
        return result;
    }
}
