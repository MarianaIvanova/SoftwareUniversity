using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Program
    {
        static void Main(string[] args)
        {
            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);

            Library libraryOne = new Library();
            Library libraryTwo = new Library(bookOne, bookTwo, bookThree);

            foreach (var book in libraryTwo)
            {
                Console.WriteLine(book);
            }
            //Sorted first by year and then by title - see public int CompareTo(Book other) in class Book,
            //and see in public IEnumerator<Book> GetEnumerator() - there is a Books.Sort() in class Library. Result:
            //The Documents in the Case - 1930
            //The Documents in the Case - 2002
            //Animal Farm - 2003
        }
    }
}
