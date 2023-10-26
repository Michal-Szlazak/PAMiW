using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Shared.BookStore;

namespace DataSeeder
{
    public class ProductSeeder
    {
        public static List<Book> GenerateProductData()
        {
            var bookFaker = new Faker<Book>()
            .RuleFor(b => b.Id, (f, b) => f.IndexFaker)
            .RuleFor(b => b.Author, (f, b) => f.Name.FullName())
            .RuleFor(b => b.Description, (f, b) => f.Lorem.Paragraph())
            .RuleFor(b => b.Title, (f, b) => f.Lorem.Sentence());

            return bookFaker.Generate(10).ToList();

        }
    }
}

