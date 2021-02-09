using Microsoft.AspNetCore.Mvc;
using PublicLibrary.BAL.Services;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using PublicLibrary.Models;
using Microsoft.Extensions.Logging;
using PublicLibrary.Web.UI.Administration.Helpers;

namespace PublicLibrary.Web.UI.Administration.Controllers
{
    public class BookController : Controller, IDisposable
    {
        private readonly IBooksService _bookService;
        private readonly IFormsService _formsService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IErrorHandler _errorHandler;

        public BookController(
            IBooksService booksService ,
            IFormsService formsService ,
            IWebHostEnvironment hostingEnvironment ,
            IErrorHandler errorHandler)
        {
            _bookService = booksService;
            _formsService = formsService;
            _hostingEnvironment = hostingEnvironment;
            _errorHandler = errorHandler;
        }

        [HttpGet] 
        public IActionResult Index()
        {

            try
            {
                _errorHandler.LogInformation("Loading Index page");

                var fileContents = System.IO.File.ReadAllText(Path.Combine(_hostingEnvironment.ContentRootPath, "Views/BookList.html"));
                return new ContentResult
                {
                    Content = fileContents,
                    ContentType = "text/html"
                };
            }
            
            catch(Exception ex)
            {
                _errorHandler.HandleErrorException(ex.Message);
                return View("Views/Error");
            }
        }


        [HttpGet]
        public IActionResult Form()
        {
            try
            {
                _errorHandler.LogInformation("Loading Form page");
                var fileContents = System.IO.File.ReadAllText(Path.Combine(_hostingEnvironment.ContentRootPath, "Views/Form.html"));
                return new ContentResult
                {
                    Content = fileContents,
                    ContentType = "text/html"
                };
            }

            catch(Exception ex)
            {
                _errorHandler.HandleErrorException(ex.Message);
                return View("Views/Error");
            }
        }


        [HttpGet]
        public IActionResult GetBooks()
        {
            try
            {
                _errorHandler.LogInformation("Calling GetBooks Method");
                return new JsonResult(_bookService.GetBooks());
            }

            catch(Exception ex)
            {
                _errorHandler.HandleErrorException(ex.Message);
                return View("Views/Error");
            }
        }

        [HttpPost]
        public IActionResult PostQuestion(string bookName, string authorName, string question)
        {
            try
            {
                _errorHandler.LogInformation("Calling PostQuestion Method");
                _formsService.AddFormQuery(new Form { AuthorName = authorName, BookName = bookName, Question = question });
                return Index();
            }

            catch(Exception ex)
            {
                _errorHandler.HandleErrorException(ex.Message);
                return View("Views/Error");
            }
        }
    }
}
