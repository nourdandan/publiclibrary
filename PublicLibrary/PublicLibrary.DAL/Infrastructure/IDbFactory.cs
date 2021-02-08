using System;
using System.Collections.Generic;
using System.Text;

namespace PublicLibrary.DAL.Infrastructure
{
   public interface IDbFactory
    {
        PublicLibraryContext Init();
    }
}
