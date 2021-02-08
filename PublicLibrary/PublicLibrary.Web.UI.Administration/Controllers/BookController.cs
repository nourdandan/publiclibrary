using Microsoft.AspNetCore.Mvc;
using PublicLibrary.BAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicLibrary.Web.UI.Administration.Controllers
{
    public class BookController : Controller
    {
        private readonly IBooksService _bookService;

        public BookController(IBooksService booksService)
        {
            _bookService = booksService;
        }

        public IActionResult Index()
        {
            return new JsonResult(_bookService.GetBooks());
        }
    }
}
