using PublicLibrary.DAL.Repositories;
using PublicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublicLibrary.BAL.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBookRepository _bookRepository;

        public BooksService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetBooks(string bookName = null)
        {
            return string.IsNullOrEmpty(bookName) ?
                    _bookRepository.GetAll() :
                    _bookRepository.GetAll().Where(b => b.Name.ToLower().Contains(bookName.ToLower()));
        }
    }
}
