using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicLibrary.DAL.Infrastructure
{
    public class DbFactory : IDbFactory
    {
        private PublicLibraryContext dbContext;
        private readonly DbContextOptions<PublicLibraryContext> _options;
        public DbFactory(DbContextOptions<PublicLibraryContext> options)
        {
            _options = options;
        }
        public PublicLibraryContext Init()
        {
            return dbContext ?? (dbContext = new PublicLibraryContext(_options));
        }
    }
}
