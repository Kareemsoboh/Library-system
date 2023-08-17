using System.Collections.Generic;
using System;

class Student
{
    public string StudentName { get; set; }
    public int StudentID { get; set; }
    public List<Book> BorrowedBooks { get; } = new List<Book>();

    public void Borrow(Book book)
    {
        if (book.IsBorrowed)
        {
            Console.WriteLine($"{book.Title} is already borrowed by another student.");
        }
        else
        {
            BorrowedBooks.Add(book);
            book.BorrowBook();
            Console.WriteLine($"{book.Title} has been borrowed by {StudentName}.");
        }
    }

    public void Return(Book book)
    {
        if (BorrowedBooks.Contains(book))
        {
            BorrowedBooks.Remove(book);
            book.ReturnBook();
            Console.WriteLine($"{book.Title} has been returned by {StudentName}.");
        }
        else
        {
            Console.WriteLine($"{book.Title} was not borrowed by {StudentName}.");
        }
    }
}
