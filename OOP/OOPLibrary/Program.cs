using System;
using System.Collections.Generic;

namespace OOPLibrary
{
    class Program
    {
        static List<Book> libraryInv = new List<Book>();
        static Stack<Book> pickedBooks = new Stack<Book>();
        static List<Book> rentedBooks = new List<Book>();

        static void Main(string[] args)
        {
            libraryInv.Add(new Book("A Promised Land", "Barack Obama", 9780241491515, "Hardback"));
            libraryInv.Add(new Book("The Song of Achilles", "Madeline Miller", 9781408891384, "Paperback"));
            libraryInv.Add(new Book("We Were Liars", "E. Lockhart", 9781471403989, "Paperback"));
            libraryInv.Add(new Book("1984", "George Orwell", 9780141036144, "Paperback"));
            libraryInv.Add(new Book("Shadow and Bone", "Leigh Bardugo", 9781510105249, "Hardback"));
            libraryInv.Add(new Book("The Song of Achilles", "Madeline Miller", 9780062060624, "Paperback"));
            libraryInv.Add(new Book("Animal Farm", "George Orwell", 9780141036137, "Paperback"));
            libraryInv.Add(new Book("Six of Crows", "Leigh Bardugo", 9781780622286, "Hardback"));

            PickBook();
        }

        static void PickBook()
        {
            bool gettingBook = true;
            bool badInput = true;
            Console.WriteLine("----------------------------\n" +
                              "       Library System       \n" +
                              "----------------------------\n" +
                              "\n" +
                              "Available Books: \n");
            while (gettingBook)
            {
                int i = 0;
                foreach (Book book in libraryInv)
                {
                    Console.WriteLine($"#{i + 1}: {book.Title} - {book.Author}\n" +
                                      $"{book.Format} - ISBN: {book.ISBN}\n" +
                                      $"\n");
                    i++;
                }
                badInput = true;
                while (badInput)
                {
                    int userChoice = -1;
                    Console.Write("Pick the book by it's # or leave your answer empty: ");
                    try
                    {
                        userChoice = int.Parse(Console.ReadLine()) - 1;
                        if (0 <= userChoice && userChoice < libraryInv.Count)
                        {
                            pickedBooks.Push(libraryInv[userChoice]);
                            libraryInv.RemoveAt(userChoice);
                            badInput = false;
                        }

                    }
                    catch (Exception)
                    {
                        gettingBook = false;
                        badInput = false;
                    }
                }

            }
            RentBook();
        }
        static void RentBook()
        {
            Console.WriteLine("\n----------------------------\n" +
                              "       Library System       \n" +
                              "----------------------------\n" +
                              "\n" +
                              "Rented Books: ");

            bool anyBooks = true;

            while (anyBooks)
            {
                if (pickedBooks.Peek() is not null)
                {

                }
                if (pickedBooks.TryPeek(out Book nextBook))
                {
                    Console.Beep();
                    Console.WriteLine($"{nextBook.Title} - {nextBook.Author} | Rented");
                    rentedBooks.Add(pickedBooks.Pop());
                }
                else
                {
                    anyBooks = false;
                    Console.WriteLine("Enjoy your books!");
                }
            }
        }
    }

    class Book
    {
        public Book(string title, string author, long isbn, string format)
        {
            this.Title = title;
            this.Author = author;
            this.ISBN = isbn;
            this.Format = format;
        }

        public string Title { get; }
        public string Author { get; }
        public long ISBN { get; }
        public string Format { get; }
    }
}
