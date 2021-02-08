using System;
using Microsoft.EntityFrameworkCore;
using PublicLibrary.Models;
namespace PublicLibrary.DAL
{
    public class PublicLibraryContext: DbContext 
    {
        public PublicLibraryContext(DbContextOptions<PublicLibraryContext> options): base(options) 
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
