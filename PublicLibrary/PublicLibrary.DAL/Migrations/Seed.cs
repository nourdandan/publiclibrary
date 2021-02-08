using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PublicLibrary.DAL.Migrations
{
    public class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PublicLibraryContext(serviceProvider
                .GetRequiredService<
                DbContextOptions<PublicLibraryContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Books.AddRange(
                    new Models.Book
                    {
                        Name = "Sapiens",
                        AuthorName = "Yuval Noah Harari"
                    },
                    new Models.Book
                    {
                         Name = "L'etranger",
                         AuthorName = "Albert Camus"
                    });

                context.SaveChanges();
            }
        }
    }
}
