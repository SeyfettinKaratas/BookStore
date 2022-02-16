using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
           using(var context=new BookStoreDBcontext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDBcontext>>())) 
           {
               if (context.Books.Any())
               {
                   return;
               }
            context.Books.AddRange(
                new Book{
                    //ID=1,
                    Title="Lean Startup",
                    GenreID=1, // personal growth
                    PageCount=200,
                    PublishDate=new DateTime(
                        2001,
                        12,
                        01)
                },
                new Book{
                    //ID=2,
                    Title="Herland",
                    GenreID=2, // Sience Fiction
                    PageCount=250,
                    PublishDate=new DateTime(
                        2010,
                        07,
                        23)
                },
                new Book{
                // ID=3,
                    Title="Dune",
                    GenreID=2, // Sience Fiction
                    PageCount=540,
                    PublishDate=new DateTime(
                        2002,
                        05,
                        23)
                }

               );
               
               context.Genres.AddRange(
                   new Genre{
                       Name="Personal Growth"
                   },
                    new Genre{
                       Name="Science Fiction"
                   },
                   new Genre{
                       Name="Romance"
                   } 
               );

               context.Authors.AddRange(
                   new Author{
                       Name="Ali",
                       Surname="Kara",                                              
                   },
                    new Author{
                       Name="Mehmet",
                       Surname="Nur",                                              
                   },
                    new Author{
                       Name="Ahmet",
                       Surname="Çizmeli",                                              
                   }
               );

               context.SaveChanges();

           }
        }
    }
}