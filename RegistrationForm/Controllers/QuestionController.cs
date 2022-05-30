using Microsoft.AspNetCore.Mvc;
using RegistrationForm.Dtos;
using RegistrationForm.Models;
using RegistrationForm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationForm.Controllers
{
    public class QuestionController : Controller
    {
        private readonly QuestionService _questionService;

        public QuestionController(QuestionService questionService)
        {
            _questionService = questionService;
        }
        public IActionResult Index()
        {
            List<QuestionDto> questions = _questionService.GetAll();
            return View(questions);
        }
        [HttpGet]
        public IActionResult Add()
        {
            Question question = new Question();
            return View(question);
        }
        [HttpPost]
        public IActionResult Add(Question question)
        {
            _questionService.Add(question);
            return View();
            //return RedirectToAction("Index");
        }
    }
}
