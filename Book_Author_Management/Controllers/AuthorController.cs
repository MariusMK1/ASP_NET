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
    public class AuthorController : Controller
    {
        public readonly AuthorService _authorService;

        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }
        public IActionResult Index()
        {
            List<AuthorDto> _authors = _authorService.GetAll();
            return View(_authors);
        }
        [HttpGet]
        public IActionResult Add()
        {
            Author author = new Author();
            return View(author);
        }
        [HttpPost]
        public IActionResult Add(Author author)
        {
            _authorService.Add(author);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _authorService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
