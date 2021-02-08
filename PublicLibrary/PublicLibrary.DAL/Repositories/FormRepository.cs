using PublicLibrary.DAL.Infrastructure;
using PublicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicLibrary.DAL.Repositories
{
    public class FormRepository: IFormRepository
    {
        private PublicLibraryContext dbContext;

        public FormRepository(IDbFactory dbFactory)
        {
            dbContext = dbFactory.Init();
        }

        public void Add(Form form)
        {
            dbContext.Add(form);
        }

        public IEnumerable<Form> GetAll()
        {
            return dbContext.Forms;
        }
    }
}
