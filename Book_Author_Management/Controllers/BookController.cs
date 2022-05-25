using Book_Author_Management.Dtos;
using Book_Author_Management.Models;
using Book_Author_Management.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Author_Management.Controllers
{
    public class BookController : Controller
    {
        private BookService _bookService;
        private AuthorService _authorServive;
        public BookController(BookService bookService, AuthorService authorService)
        {
            _bookService = bookService;
            _authorServive = authorService;
        }

        public IActionResult Index()
        {
            List<BookDto> _books = _bookService.GetAll();
            return View(_books);
        }
        [HttpGet]
        public IActionResult Add()
        {
            BookDto book = new BookDto();
            
            book.Authors = _authorServive.GetAll();
            return View(book);
        }
        [HttpPost]
        public IActionResult Add(BookDto bookDto)
        {
            _bookService.Add(bookDto);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _bookService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
