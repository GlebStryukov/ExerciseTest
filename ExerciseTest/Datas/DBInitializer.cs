using ExerciseTest.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseTest.Datas
{
    public class DBInitializer
    {
        //Initialize data`s for database
        public static void Initialize(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<BooksAuthorContext>();
                if (!context.Books.Any())
                {
                    context.Books.AddRange(
                      new Book
                      {
                          Title = "CLR via C#",
                          Description = "This book about working C# and CLR",
                          Edition = "...",
                          Publeshid_At = DateTime.Now.AddYears(-4).Date
                      },

                      new Book
                      {
                          Title = "Patterns OOP",
                          Description = "This book about all patterns",
                          Edition = "Deluxe",
                          Publeshid_At = DateTime.Now.AddYears(-1).Date
                      },
                      new Book
                      {
                          Title = "War and Peace",
                          Description = "The novel chronicles the French invasion of Russia and the impact of the Napoleonic era on Tsarist society through the stories of five Russian aristocratic families",
                          Edition = "Season pass",
                          Publeshid_At = DateTime.Parse("01.01.1869")
                      });
                    context.SaveChanges();
                }
                if (!context.Authors.Any())
                {
                    context.Authors.AddRange(
                        new Author
                        {
                            FullName = "Jeffrey Richter",
                            DoB = DateTime.Parse("27.07.1964")
                        },
                        new Author
                        {
                            FullName = "John Vlissides",
                            DoB = DateTime.Parse("02.08.1961")
                        },
                        new Author
                        {
                            FullName = "Ralph Johnson",
                            DoB = DateTime.Parse("07.10.1955")
                        },
                        new Author
                        {
                            FullName = "Erich Gamma",
                            DoB = DateTime.Parse("13.03.1961")
                        },
                        new Author
                        {
                            FullName = "Lev Nikolayevich Tolstoy",
                            DoB = DateTime.Parse("09.09.1828")
                        }
                        );
                    context.SaveChanges();
                    if (!context.BooksAuthors.Any())
                    {
                        context.BooksAuthors.AddRange(
                            new BookAuthor
                            {
                                BookId = 1,
                                AuthorId = 1
                            },
                            new BookAuthor
                            {
                                BookId = 3,
                                AuthorId = 5
                            },
                            new BookAuthor
                            {
                                BookId = 2,
                                AuthorId = 2
                            },
                            new BookAuthor
                            {
                                BookId = 2,
                                AuthorId = 3
                            },
                            new BookAuthor
                            {
                                BookId = 2,
                                AuthorId = 4
                            }
                            );
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}