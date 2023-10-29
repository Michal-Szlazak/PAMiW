using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Shared.BookStore;

namespace DataSeeder
{
    public class BookSeeder
    {

        public static List<Book> GenerateBookData()
        {
            int bookId = 1;
            var bookFaker = new Faker<Book>()
            .UseSeed(123456)
            .RuleFor(b => b.Id, (f, b) => bookId++)
            .RuleFor(b => b.Author, (f, b) => f.Name.FullName())
            .RuleFor(b => b.Description, (f, b) => f.Random.Words(10))
            .RuleFor(b => b.Title, (f, b) => f.Random.Words(2));

            return bookFaker.Generate(10).ToList();

        }
    }
}

