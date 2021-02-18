using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstoreDatabase.Models
{
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            BookstoreDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BookstoreDbContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            
            if(!context.Books.Any())
            {
                context.Books.AddRange(

                    new Book
                    {
                        Title = "Les Miserables",
                        Author = "Victor Hugo",
                        Publisher = "Signet",
                        ISBN = 9780451419439,
                        Category = "Fiction, Classic",
                        Price = 9.95
                    },

                    new Book
                    {
                        Title = "Team of Rivals",
                        Author = "Doris Kearns Goodwin",
                        Publisher = "Simon & SchusterSignet",
                        ISBN = 9780743270755,
                        Category = "Non-Fiction, Biography",
                        Price = 14.58
                    },

                    new Book
                    {
                        Title = "The Snowball",
                        Author = "Alice Schroeder",
                        Publisher = "Bantam",
                        ISBN = 9780553384611,
                        Category = "Non-Fiction, Biography",
                        Price = 21.54
                    }
                ) ;
                context.SaveChanges();
            }
        }
    }
}
