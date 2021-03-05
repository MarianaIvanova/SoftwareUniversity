using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        public Library(params Book[] books)//The other way without params is to make two ctors 1 - (), 2 - (Book[] books)
        {
            //this.Books = books.ToList();
            this.Books = new SortedSet<Book>(books);
        }
        public SortedSet<Book> Books { get; set; }

        public IEnumerator<Book> GetEnumerator()
        {
            //throw new NotImplementedException();//Automatic proposal
            //return Books.GetEnumerator();//cause the list has enumerator in it!!!
            //Books.Sort();// - if we do it only with this and this.Books = books.ToList() - 90/100 in Judge!
            return new LibraryIterator(Books.ToList());//this is the way to invoke our enumerator. 
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            //throw new NotImplementedException();//Automatic proposal
            return GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private int currentIndex = -1;
            public LibraryIterator(List<Book> books)
            {
                this.Books = books;
            }
            public List<Book> Books { get; set; }
            public Book Current => Books[currentIndex];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                //throw new NotImplementedException();//Automatically generated
            }

            public bool MoveNext()
            {
                currentIndex++;
                if(Books.Count <= currentIndex)
                {
                    return false;
                }

                return true;
                //Other method to write the above:
                //return ++currentIndex < Books.Count;
            }

            public void Reset()
            {
                currentIndex = -1;
            }
        }
    }
}
