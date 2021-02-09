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

namespace PublicLibrary.Web.UI.Administration.Controllers
{
    public class BookController : Controller
    {
        private readonly IBooksService _bookService;
        private readonly IFormsService _formsService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public BookController(IBooksService booksService , IFormsService formsService  ,IHostingEnvironment hostingEnvironment)
        {
            _bookService = booksService;
            _formsService = formsService;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var fileContents = System.IO.File.ReadAllText(Path.Combine(_hostingEnvironment.ContentRootPath, "Views/BookList.html"));
            return new ContentResult
            {
                Content = fileContents,
                ContentType = "text/html"
            };
        }


        [HttpGet]
        public IActionResult Form()
        {
            var fileContents = System.IO.File.ReadAllText(Path.Combine(_hostingEnvironment.ContentRootPath, "Views/Form.html"));
            return new ContentResult
            {
                Content = fileContents,
                ContentType = "text/html"
            };
        }


        [HttpGet]
        public IActionResult GetBooks()
        {
            return new JsonResult(_bookService.GetBooks());
        }

        [HttpPost]
        public IActionResult PostQuestion(string bookName, string authorName, string question)
        {
            _formsService.AddFormQuery(new Form { AuthorName = authorName, BookName = bookName, Question = question });
            return Index();
        }
    }
}
