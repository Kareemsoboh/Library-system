using System;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public bool IsBorrowed { get; set; }

    public void BorrowBook()
    {
        if (!IsBorrowed)
        {
            IsBorrowed = true;
            //Console.WriteLine($"{Title} has been borrowed.");
        }
        else
        {
            //Console.WriteLine($"{Title} is already borrowed.");
        }
    }

    public void ReturnBook()
    {
        if (IsBorrowed)
        {
            IsBorrowed = false;
            Console.WriteLine($"{Title} has been returned.");
        }
        else
        {
            Console.WriteLine($"{Title} is not currently borrowed.");
        }
    }
}
