using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        // Example books and students
        Book book1 = new Book { Title = "Book 1", Author = "Author 1", ISBN = "ISBN1" };
        Book book2 = new Book { Title = "Book 2", Author = "Author 2", ISBN = "ISBN2" };
        Student student1 = new Student { StudentName = "John", StudentID = 1 };
        Student student2 = new Student { StudentName = "Alice", StudentID = 2 };

        library.AddBook(book1);
        library.AddBook(book2);
        library.RegisterStudent(student1);
        library.RegisterStudent(student2);

        int choice;
        do
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. View all books.");
            Console.WriteLine("2. View available books.");
            Console.WriteLine("3. Borrow a book.");
            Console.WriteLine("4. Return a book.");
            Console.WriteLine("5. Register a student.");
            Console.WriteLine("6. Exit.");
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());
            string isbn;
            switch (choice)
            {

                case 1:
                    // View all books
                    foreach (var book in library.ListOfBooks)
                    {
                        Console.WriteLine($"{book.Title} by {book.Author} - {(book.IsBorrowed ? "Borrowed" : "Available")}");
                    }
                    break;

                case 2:
                    // View available books
                    library.ViewAvailableBooks();
                    break;

                case 3:
                    // Borrow a book
                    Console.Write("Enter student ID: ");
                    int studentID = int.Parse(Console.ReadLine());
                    Student borrower = library.ListOfStudents.FirstOrDefault(s => s.StudentID == studentID);

                    if (borrower == null)
                    {
                        Console.WriteLine("Student not found.");
                    }
                    else
                    {
                        Console.Write("Enter ISBN of the book to borrow: ");
                         isbn = Console.ReadLine();
                        Book bookToBorrow = library.ListOfBooks.FirstOrDefault(b => b.ISBN == isbn);

                        if (bookToBorrow == null)
                        {
                            Console.WriteLine("Book not found.");
                        }
                        else
                        {
                            borrower.Borrow(bookToBorrow);
                        }
                    }
                    break;

                case 4:
                    // Return a book
                    Console.Write("Enter student ID: ");
                    studentID = int.Parse(Console.ReadLine());
                    borrower = library.ListOfStudents.FirstOrDefault(s => s.StudentID == studentID);

                    if (borrower == null)
                    {
                        Console.WriteLine("Student not found.");
                    }
                    else
                    {
                        Console.Write("Enter ISBN of the book to return: ");
                        isbn = Console.ReadLine();
                        Book bookToReturn = borrower.BorrowedBooks.FirstOrDefault(b => b.ISBN == isbn);

                        if (bookToReturn == null)
                        {
                            Console.WriteLine("Book not found.");
                        }
                        else
                        {
                            borrower.Return(bookToReturn);
                        }
                    }
                    break;

                case 5:
                    // Register a student
                    Student newStudent = new Student();
                    Console.Write("Enter student name: ");
                    newStudent.StudentName = Console.ReadLine();
                    Console.Write("Enter student ID: ");
                    newStudent.StudentID = int.Parse(Console.ReadLine());
                    library.RegisterStudent(newStudent);
                    break;

                case 6:
                    Console.WriteLine("Exiting the library system.");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        } while (choice != 6);
    }
}
