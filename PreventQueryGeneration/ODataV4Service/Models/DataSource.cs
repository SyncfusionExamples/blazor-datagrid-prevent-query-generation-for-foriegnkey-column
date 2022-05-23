using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataV4Service.Models
{
    public static class DataSource
    {
        private static IList<Book> _books { get; set; }

        //public static IList<Book> GetBooks()
        //{
        //    if (_books != null)
        //    {
        //        return _books;
        //    }

        //    _books = new List<Book>();

        //    var newGuid = Guid.NewGuid();

        //    Book related = new Book
        //    {
        //        Id = 1,
        //        Name = "n&g systems ...",               
        //        Gender = Gender.Male.ToString(),
        //        RegistrationDate = DateTime.Now,
        //        Active = true,
        //        IsDeleted = false,
        //        CreditLimit = 1000                
        //    };
        //    _books.Add(related);

        //    // book #1
        //    Book book = new Book
        //    {
        //        Id = 2,               
        //        Name = "testing & testing",               
        //        Gender = Gender.Female.ToString(),
        //        RegistrationDate = DateTime.Now.AddDays(-2),
        //        Active = false,
        //        IsDeleted = false,
        //        CreditLimit = 2000
        //    };
        //    _books.Add(book);

        //    // book #2
        //    book = new Book
        //    {
        //        Id = 3,               
        //        Name = "r&b alternative",
        //      Gender = Gender.Female.ToString(),
        //        RegistrationDate = DateTime.Now.AddDays(-3),
        //        Active = true,
        //        IsDeleted = false,
        //        CreditLimit = 3000
        //    };
        //    _books.Add(book);

        //    book = new Book
        //    {
        //        Id = 4,
               
        //        Name = "R&C consultants",
        //        Gender = Gender.Male.ToString(),             
        //        RegistrationDate = DateTime.Now.AddDays(-4),
        //        Active = true,
        //        IsDeleted = false,
        //        CreditLimit = 4000
        //    };
        //    _books.Add(book);

        //    book = new Book
        //    {
        //        Id = 5,
               
        //        Name = "JP P&G ",
        //        Gender = Gender.Female.ToString(),              
        //        RegistrationDate = DateTime.Now.AddDays(-5),
        //        Active = true,
        //        IsDeleted = false,
        //        CreditLimit = 5000
        //    };
        //    _books.Add(book);


        //    book = new Book
        //    {
        //        Id = 6,
             
        //        Name = "H&K",
        //        Gender = Gender.Female.ToString(),               
        //        RegistrationDate = DateTime.Now.AddDays(-6),
        //        Active = true,
        //        IsDeleted = false,
        //        CreditLimit = 6000
        //    };
        //    _books.Add(book);


        //    book = new Book
        //    {
        //        Id = 7,
               
        //        Name = "HHM",
        //        Gender = Gender.Female.ToString(),              
        //        RegistrationDate = DateTime.Now.AddDays(-7),
        //        Active = true,
        //        IsDeleted = false,
        //        CreditLimit = 7000
        //    };
        //    _books.Add(book);



        //    book = new Book
        //    {
        //        Id = 8,                
        //        Name = "TLC (TELECOM)",
        //        Gender = Gender.Male.ToString(),            
        //        RegistrationDate = DateTime.Now.AddDays(-8),
        //        Active = true,
        //        IsDeleted = false,
        //        CreditLimit = 8000
        //    };
        //    _books.Add(book);


        //    book = new Book
        //    {
        //        Id = 9,              
        //        Name = "Google",
        //        Gender = Gender.Male.ToString(),              
        //        RegistrationDate = DateTime.Now.AddDays(-8),
        //        Active = true,
        //        IsDeleted = false,
        //        CreditLimit = 9000
        //    };
        //    _books.Add(book);

        //    return _books;
        //}
    }
}
