using System.Collections.Generic;
using System;
using System.Linq;

class Library
{
    public List<Book> ListOfBooks { get; } = new List<Book>();
    public List<Student> ListOfStudents { get; } = new List<Student>();

    public void AddBook(Book book)
    {
        ListOfBooks.Add(book);
        Console.WriteLine($"{book.Title} has been added to the library.");
    }

    public void RemoveBook(Book book)
    {
        ListOfBooks.Remove(book);
        Console.WriteLine($"{book.Title} has been removed from the library.");
    }

    public void RegisterStudent(Student student)
    {
        ListOfStudents.Add(student);
        Console.WriteLine($"{student.StudentName} has been registered.");
    }

    public void ViewAvailableBooks()
    {
        List<Book> availableBooks = ListOfBooks.Where(book => !book.IsBorrowed).ToList();
        Console.WriteLine("Available Books:");
        foreach (var book in availableBooks)
        {
            Console.WriteLine($"{book.Title} by {book.Author}");
        }
    }

    public void ViewBorrowedBooks()
    {
        List<Book> borrowedBooks = ListOfBooks.Where(book => book.IsBorrowed).ToList();
        Console.WriteLine("Borrowed Books:");
        foreach (var book in borrowedBooks)
        {
            Console.WriteLine($"{book.Title} by {book.Author}");
        }
    }
}
