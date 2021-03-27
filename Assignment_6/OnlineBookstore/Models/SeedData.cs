using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Models
{
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            OnlineBookstoreDbContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<OnlineBookstoreDbContext>();

            //Migrate database
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            
            //Seed new data
            if (!context.Books.Any())
            {
                context.Books.AddRange(

                    new Book
                    {
                        Title = "Les Miserables",
                        AuthorFirstName = "Victor",
                        AuthorLastName = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 9.95,
                        Pages = 1488
                    },
                    new Book
                    {
                        Title = "Team of Rivals",
                        AuthorFirstName = "Doris Kearns",
                        AuthorLastName = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 14.58,
                        Pages = 944
                    },
                    new Book
                    {
                        Title = "The Snowball",
                        AuthorFirstName = "Alice",
                        AuthorLastName = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 11.61,
                        Pages = 832
                    },
                    new Book
                    {
                        Title = "American Ulysses",
                        AuthorFirstName = "Ronald C.",
                        AuthorLastName = "White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 13.33,
                        Pages = 864
                    },
                    new Book
                    {
                        Title = "Unbroken",
                        AuthorFirstName = "Laura",
                        AuthorLastName = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = 15.95,
                        Pages = 528
                    },
                    new Book
                    {
                        Title = "The Great Train Robbery",
                        AuthorFirstName = "Michael",
                        AuthorLastName = "Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = 14.99,
                        Pages = 288
                    },
                    new Book
                    {
                        Title = "Deep Work",
                        AuthorFirstName = "Cal",
                        AuthorLastName = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 21.66,
                        Pages = 304
                    },
                    new Book
                    {
                        Title = "It's Your Ship",
                        AuthorFirstName = "Michael",
                        AuthorLastName = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 14.58,
                        Pages = 240
                    },
                    new Book
                    {
                        Title = "The Virgin Way",
                        AuthorFirstName = "Richard",
                        AuthorLastName = "Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Classification = "Non-Fiction",
                        Category = "Business",
                        Price = 29.16,
                        Pages = 400
                    },
                    new Book
                    {
                        Title = "Sycamore Row",
                        AuthorFirstName = "John",
                        AuthorLastName = "Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Classification = "Fiction",
                        Category = "Thrillers",
                        Price = 15.03,
                        Pages = 642
                    },
                    new Book
                    {
                        Title = "The Hunger Games",
                        AuthorFirstName = "Suzanne",
                        AuthorLastName = "Collins",
                        Publisher = "Scholastic",
                        ISBN = "978-0439023481",
                        Classification = "Science Fiction",
                        Category = "Action",
                        Price = 9.96,
                        Pages = 374
                    },
                    new Book
                    {
                        Title = "The Host",
                        AuthorFirstName = "Stephenie",
                        AuthorLastName = "Meyer",
                        Publisher = "Little, Brown and Co.",
                        ISBN = "978-0316026697",
                        Classification = "Science Fiction",
                        Category = "Thrillers",
                        Price = 25.03,
                        Pages = 619
                    },
                    new Book
                    {
                        Title = "Divergent",
                        AuthorFirstName = "Veronica",
                        AuthorLastName = "Roth",
                        Publisher = "Harper Collins Children's",
                        ISBN = "978-0062084323",
                        Classification = "Science Fiction",
                        Category = "Action",
                        Price = 16.99,
                        Pages = 487
                    }
                );

                //Save data
                context.SaveChanges();
            }
        }
    }
}
