using PublicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicLibrary.BAL.Services
{
    public interface IBooksService
    {
        IEnumerable<Book> GetBooks(string name = null);
    }
}
