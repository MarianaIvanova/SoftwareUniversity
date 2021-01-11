using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            //throw new NotImplementedException();
            int result = x.Title.CompareTo(y.Title);//alphabetically
            if (result == 0)
            {
                result = y.Year.CompareTo(x.Year);//newest to oldest
            }

            return result;
        }
    }
}
