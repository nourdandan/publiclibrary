using PublicLibrary.DAL.Repositories;
using PublicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicLibrary.BAL.Services
{
    public class FormsService : IFormsService
    {
        private readonly IFormRepository _formRepository;

        public FormsService(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        public void AddFormQuery(Form form)
        {
            if(form.IsValid())
            _formRepository.Add(form);
        }

    }
}
