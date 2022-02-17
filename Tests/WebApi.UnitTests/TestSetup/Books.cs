using System;
using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDBcontext context)
        {
            context.Books.AddRange(
                new Book{          
                    Title="Lean Startup",
                    GenreID=1, 
                    PageCount=200,
                    PublishDate=new DateTime(
                        2001,
                        12,
                        01)
                },
                new Book{                    
                    Title="Herland",
                    GenreID=2, 
                    PageCount=250,
                    PublishDate=new DateTime(
                        2010,
                        07,
                        23)
                },
                new Book{                
                    Title="Dune",
                    GenreID=2,
                    PageCount=540,
                    PublishDate=new DateTime(
                        2002,
                        05,
                        23)
                }
            );

        }
    }
}