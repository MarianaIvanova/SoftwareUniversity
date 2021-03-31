namespace BookShop
{
    using Data;
    using Initializer;
    using System.Text;
    using System.Linq;
    using System;
    using Microsoft.EntityFrameworkCore;
    using BookShop.Models.Enums;
    using System.Collections.Generic;
    using BookShop.Models;
    using System.Globalization;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);
            ////2. Age Restriction 
            //string command = Console.ReadLine();
            //Console.WriteLine(GetBooksByAgeRestriction(db, command));

            ////3. Golden Books
            //Console.WriteLine(GetGoldenBooks(db));

            ////4. Books by Price
            //Console.WriteLine(GetBooksByPrice(db));

            ////5. Not Released In
            //int year = int.Parse(Console.ReadLine());
            //Console.WriteLine(GetBooksNotReleasedIn(db, year));

            ////6. Book Titles by Category
            //string input = Console.ReadLine();
            //Console.WriteLine(GetBooksByCategory(db, input));

            ////7. Released Before Date
            //string date = Console.ReadLine();
            //Console.WriteLine(GetBooksReleasedBefore(db, date));

            ////8. Author Search
            //string input = Console.ReadLine();
            //Console.WriteLine(GetAuthorNamesEndingIn(db, input));

            ////9. Book Search
            //string input = Console.ReadLine();
            //Console.WriteLine(GetBookTitlesContaining(db, input));

            ////10. Book Search by Author
            //string input = Console.ReadLine();
            //Console.WriteLine(GetBooksByAuthor(db, input));

            ////11. Count Books
            //int lengthCheck = int.Parse(Console.ReadLine());
            //Console.WriteLine(CountBooks(db, lengthCheck));

            ////12. Total Book Copies
            //Console.WriteLine(CountCopiesByAuthor(db));

            ////13. Profit by Category
            //Console.WriteLine(GetTotalProfitByCategory(db));

            ////14. Most Recent Books
            //Console.WriteLine(GetMostRecentBooks(db));

            ////15. Increase Prices
            //IncreasePrices(db);

            //16. Remove Books
            Console.WriteLine(RemoveBooks(db));          
        }
        //2. Age Restriction Mine - working
        public static string GetBooksByAgeRestrictionMine(BookShopContext context, string command)
        {
            string commandNew = (command.ToUpper().Substring(0, 1) + command.ToLower().Substring(1, command.Length - 1));
            AgeRestriction commandCorrect = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), commandNew);

            var books = context.Books
                .Where(x => x.AgeRestriction == commandCorrect)
                .Select(x => new { Title = x.Title})
                .OrderBy(x => x.Title)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }
        //2. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var commandCorrect = Enum.Parse<AgeRestriction>(command, true);//true ignores casing

            var books = context.Books
                .Where(x => x.AgeRestriction == commandCorrect)
                .Select(x => x.Title)//It shouldn't be .Select(x => new { Title = x.Title}) if we use string.Join()
                .OrderBy(x => x)
                .ToList();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }
        //3. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            //Mine:
            //var commandCorrect = Enum.Parse<EditionType>("Gold", false);//false doesn't ignores casing

            var books = context.Books
                //.Where(x => x.EditionType == commandCorrect && x.Copies < 5000)//Mine
                .Where(x => x.EditionType == EditionType.Gold && x.Copies < 5000)
                .Select(x => new
                {
                    BookId = x.BookId,
                    Title = x.Title
                })
                .OrderBy(x => x.BookId)
                .ToList();

            //StringBuilder sb = new StringBuilder();
            //foreach (var book in books)
            //{
            //    sb.AppendLine(book.Title);
            //}
            //return sb.ToString().TrimEnd();
            var result = string.Join(Environment.NewLine, books.Select(x => x.Title));

            return result;
        }
        //4. Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Price > 40)
                .Select(x => new
                {
                    Title = x.Title,
                    Price = x.Price,
                })
                .OrderByDescending(x => x.Price)
                .ToList();

            //var result = string.Join(Environment.NewLine, books.Select(x => $"{x.Title} - ${x.Price:F2}"));

            //return result;

            StringBuilder sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }
        //5. Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .ToList();

            string result = string.Join(Environment.NewLine, books.Select(x => x.Title));

            return result;
        }
        //6. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] inputCategories = input
                .Split(" ")
                .Select(x => x.ToLower())
                .ToArray();
            //with Linq, starting from Books
            var books = context.Books
                .Include(x => x.BookCategories)
                .ThenInclude(x => x.Category)
                .Where(x => x.BookCategories.Any(a => inputCategories.Contains(a.Category.Name.ToLower())))//Някоя категория - Any
                .Select(x => new
                {
                    Title = x.Title,
                })
                .OrderBy(x => x.Title)
                .ToList();

            ////with Linq, starting from Books
            //var booksCategories = context.BooksCategories
            //    .Include(x => x.Category)
            //    .Where(x => inputCategories.Contains(x.Category.Name.ToLower()))
            //    .Select(x => new
            //    {
            //        Title = x.Book.Title,
            //    })
            //    .OrderBy(x => x.Title)
            //    .ToList();
            //string result = string.Join(Environment.NewLine, booksCategories);

            ////Wtih foreach
            //List<Book> books = new List<Book>();

            //var allBooks = context.Books
            //    .Include(x => x.BookCategories)
            //    .ThenInclude(x => x.Category)
            //    .ToList();
            //foreach (var book in allBooks)
            //{
            //    foreach (var bookCategory in book.BookCategories)
            //    {
            //        if(inputCategories.Contains(bookCategory.Category.Name.ToLower()))
            //        {
            //            books.Add(book);
            //        }
            //    }
            //}

            string result = string.Join(Environment.NewLine, books.Select(x => x.Title));

            return result;
        }

        //7. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {

           var parseDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);//using System.Globalization;

            var books = context.Books
                .Where(x => x.ReleaseDate < parseDate)
                .Select(x => new
                {
                    Title = x.Title,
                    EditionType = x.EditionType,
                    ReleaseDate = x.ReleaseDate,
                    Price = x.Price,
                })
                .OrderByDescending(x => x.ReleaseDate)
                .ToList();

            string result = string.Join(Environment.NewLine, books.Select(x => $"{x.Title} - {x.EditionType} - ${x.Price:F2}"));

            return result;
        }

        //8. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                //.Where(x => x.FirstName.EndsWith(input))//Mine - working
                .Where(x => EF.Functions.Like(x.FirstName, $"%{input}"))//Teache's one
                .Select(x => new
                {
                    FullName = x.FirstName + " " + x.LastName,
                })
                .OrderBy(x => x.FullName)
                .ToList();

            string result = string.Join(Environment.NewLine, authors.Select(x => x.FullName));

            return result;
        }
        //9. Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => new { Title = x.Title })
                .OrderBy(x => x.Title)
                .ToList();
            string result = string.Join(Environment.NewLine, books.Select(x => x.Title));

            return result;
        }

        //10. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Include(x => x.Author)
                //.Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))// Mine - working
                .Where(x => EF.Functions.Like(x.Author.LastName.ToLower(), $"{input.ToLower()}"))
                .Select(x => new
                {
                    BookId = x.BookId,
                    Title = x.Title,
                    Author = x.Author.FirstName + " " + x.Author.LastName,
                })
                .OrderBy(x => x.BookId)
                .ToList();
            string result = string.Join(Environment.NewLine, books.Select(x => $"{x.Title} ({x.Author})"));

            return result;
        }
        //11. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .ToList();

            return books.Count();
        }

        //12. Total Book Copies 
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authorsCopies = context.Authors
                .Include(x => x.Books)
                .Select(x => new
                {
                    FullName = x.FirstName + " " + x.LastName,
                    AuthorCopies = x.Books.Sum(a => a.Copies),
                })
                .OrderByDescending(x => x.AuthorCopies)
                .ToList();

            string result = string.Join(Environment.NewLine, authorsCopies.Select(x => $"{x.FullName} - {x.AuthorCopies}"));
            return result;
        }
        //13. Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var profitPerCategories = context.Categories
                .Select(x => new//x here is the box, after this we have x.Key and aggregated function
                {
                    CategoryName = x.Name,
                    ProfitPerCategory = x.CategoryBooks.Sum(a => a.Book.Price * a.Book.Copies),
                })
                .OrderByDescending(x => x.ProfitPerCategory)
                .ThenBy(x => x.CategoryName)
                .ToList();

            string result = string.Join(Environment.NewLine, profitPerCategories.Select(x => $"{x.CategoryName} ${x.ProfitPerCategory:F2}"));

            return result;
        }
        //14. Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var BooksLatest3Categories = context.Categories
                .Select(x => new
                {
                    CategoryName = x.Name,
                    BooksLatest3 = x.CategoryBooks.OrderByDescending(x => x.Book.ReleaseDate).Take(3)
                        .Select(x => new
                        {
                            BookTitle = x.Book.Title,
                            ReleaseDate = x.Book.ReleaseDate,
                        })
                        .ToList(),
                })
                .OrderBy(x => x.CategoryName)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var category in BooksLatest3Categories)
            {
                sb.AppendLine($"--{category.CategoryName}");
                foreach (var book in category.BooksLatest3)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }
        //15. Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            var booksBefore2010 = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToList();
            foreach (var book in booksBefore2010)
            {
                book.Price = book.Price + 5;
            }

            context.SaveChanges();
        }

        //16. Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            var booksToRemove = context.Books
                .Where(x => x.Copies < 4200)
                .ToList();
            
            //foreach (var book in booksToRemove)
            //{
            //    context.Books.Remove(book);
            //}
            
            context.Books.RemoveRange(booksToRemove);//Teacher

            context.SaveChanges();

            return booksToRemove.Count();
        }
    }
}
