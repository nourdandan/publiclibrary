using PublicLibrary.DAL.Infrastructure;
using PublicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicLibrary.DAL.Repositories
{
    public class BookRepository: IBookRepository
    {
        private PublicLibraryContext dbContext;
        public BookRepository(IDbFactory dbFactory)
        {
            dbContext = dbFactory.Init();
        }

        public IEnumerable<Book> GetAll()
        {
            return dbContext.Books;
        }
    }
}
