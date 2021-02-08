using PublicLibrary.DAL.Infrastructure;
using PublicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicLibrary.DAL.Repositories
{
    public interface IBookRepository: IRepository<Book>
    {
    }
}
