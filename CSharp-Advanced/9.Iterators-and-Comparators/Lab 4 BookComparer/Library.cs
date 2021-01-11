using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            this.Books = new SortedSet<Book>(books, new BookComparator());//We have added our BookComparator here!
        }

        public SortedSet<Book> Books { get; set; }
        public IEnumerator<Book> GetEnumerator()
        {
            //throw new NotImplementedException();
            return new LibraryIterator(Books.ToList());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            //throw new NotImplementedException();
            return GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            int index = -1;

            public LibraryIterator(List<Book> books)
            {
                Books = books;
            }

            public List<Book> Books { get; set; }

            public Book Current => this.Books[index];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                //throw new NotImplementedException();//Automatically generated
            }

            public bool MoveNext()
            {
                index++;
                if(Books.Count <= index)
                {
                    return false;
                }

                return true;
            }

            public void Reset()
            {
                index = -1;
            }
        }
    }
}
