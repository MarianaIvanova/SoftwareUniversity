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
            this.Books = books.ToList();
        }
        public List<Book> Books { get; set; }

        public IEnumerator<Book> GetEnumerator()
        {
            //throw new NotImplementedException();//Automatic proposal
            return Books.GetEnumerator();//cause the list has enumerator in it!!!
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            //throw new NotImplementedException();//Automatic proposal
            return GetEnumerator();
        }
    }
}
